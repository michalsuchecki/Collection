﻿using Microsoft.AspNetCore.Hosting;
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
            return Guid.NewGuid().ToString("N");
        }

        public string AddImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                var filename = GenerateImageName();

                if (!Directory.Exists(_workDirectory))
                    Directory.CreateDirectory(_workDirectory);

                var FileWithPath = Path.Combine(_workDirectory, filename);

                using (var stream = new FileStream(FileWithPath + Globals.imageSufix, FileMode.Create))
                {
                    file.CopyTo(stream);
                    MakeThumbnail(file, _workDirectory, filename);
                }
                return filename;
            }
            return String.Empty;
        }

        private void MakeThumbnail(IFormFile file, string path, string filename)
        {
            path = Path.Combine(path, Globals.toysThumbnailsDirectory);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var FileWithPath = Path.Combine(path, filename);

            using (var memory = new MemoryStream())
            using (var output = new FileStream(FileWithPath + Globals.thumbnailSufix, FileMode.Create))
            {
                file.CopyTo(memory);
                memory.Seek(0, SeekOrigin.Begin);

                var img = Image.Load(memory);

                var thumb = img.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Crop,
                    Size = Globals.ThumbSize,
                });

                thumb.Save(output);           
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
