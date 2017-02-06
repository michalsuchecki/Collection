using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImageSharp;
using ImageSharp.Formats;
using ImageSharp.Processing;


namespace MyInflatables.Helpers
{
    public class ImageHelper
    {
        private IHostingEnvironment _environment;
        private string _workDirectory;

        public ImageHelper(IHostingEnvironment environment)
        {
            _environment = environment;
            _workDirectory = Path.Combine(_environment.WebRootPath, Globals.toysDirectory);
        }

        public string GenerateImageName()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public string AddImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                // Large image
                var filename = GenerateImageName() + "_l.jpg";
                var FileWithPath = Path.Combine(_workDirectory, filename);

                using (var stream = new FileStream(FileWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    //MakeThumbnail(stream, FileWithPath);
                }

                // TODO: Preview 
                

                return filename;
            }

            return "";
        }

        private void MakeThumbnail(Stream input, string path)
        {
            Configuration.Default.AddImageFormat(new JpegFormat());
            Configuration.Default.AddImageFormat(new PngFormat());
            Configuration.Default.AddImageFormat(new BmpFormat());

            using (var output = new FileStream(path + ".jpg", FileMode.Create))
            {
                var img = new Image(input);
                img.Resize(new ResizeOptions()
                {
                    Mode = ResizeMode.Crop,
                    Size = Globals.ThumbSize
                });

                img.Quality = 75;
                img.ExifProfile = null;
                img.Save(output);

            }


        }

        public void RemoveImage(string filename)
        {
            var path = Path.Combine(_workDirectory, filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
