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


namespace Collection.Helpers
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
                var filename = GenerateImageName();;
                var FileWithPath = Path.Combine(_workDirectory, filename);

                using (var stream = new FileStream(FileWithPath + Globals.imageSufix, FileMode.Create))
                {
                    file.CopyTo(stream);
                    MakeThumbnail(file, FileWithPath);
                }
                return filename;
            }
            return String.Empty;
        }

        private void MakeThumbnail(IFormFile file, string path)
        {
            //Configuration.Default.AddImageFormat(new JpegFormat());
            //using (var stream = new MemoryStream())
            //using (var output = new FileStream(path + Globals.thumbnailSufix, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //    stream.Seek(0, SeekOrigin.Begin);

            //    var img = Image.Load(stream);
            //    var result = img.Crop(Globals.ThumbSize.Width, Globals.ThumbSize.Height);
            //    result.Save(output);
            //}


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
