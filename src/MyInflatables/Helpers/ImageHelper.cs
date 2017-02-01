using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

                using (var stream = new FileStream(Path.Combine(_workDirectory, filename), FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // TODO: Preview 

                return filename;
            }

            return "";
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
