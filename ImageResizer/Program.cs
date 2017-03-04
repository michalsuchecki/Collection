using System;
using System.IO;
using System.Linq;
using ImageSharp;
using ImageSharp.Processing;


namespace ImageResizer
{
    class Program
    {
        static string WorkPath = @"..\..\..\src\MyInflatables\wwwroot\img\toys\";
        static Size ImageDestSize = new Size(width: 400, height: 320);

        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(WorkPath);
            var files = Directory.GetFiles(".", "*_l.jpg");

            foreach (var file in files)
                ResizeImage(Path.GetFileName(file));

            if (!Directory.Exists("thumb"))
                Directory.CreateDirectory("thumb");


            var thumbs = Directory.GetFiles(".", "*.jpg").Where(s => !s.Contains("_l")).ToArray();

            foreach (var thumb in thumbs)
            {
                File.Move(thumb, Path.Combine("thumb", thumb));
            }

            Console.ReadKey();
        }

        static void ResizeImage(string filename)
        {
            using (var file = File.Open(filename, FileMode.Open))
            {
                file.Seek(0, SeekOrigin.Begin);

                Image img = new Image(file);
                Size size = new Size();

                float resizePct, resizeW, resizeH;

                resizeW = ((float)ImageDestSize.Width / (float)img.Width);
                resizeH = ((float)ImageDestSize.Height / (float)img.Height);
                resizePct = (resizeH < resizeW) ? resizeH : resizeW;

                size.Width = (int)(img.Width * resizePct);
                size.Height = (int)(img.Height * resizePct);

                filename = filename.Replace("_l", String.Empty);

                Console.WriteLine(filename + " Size: " + file.Length + " Resolution: " + img.Width + "x" + img.Height + "->"
                   + size.Width + "x" + size.Height + " Type: " + img.CurrentImageFormat.MimeType);

                img.Resize(new ResizeOptions()
                {
                    Size = size,
                    Mode = ResizeMode.Crop
                });

                img.Save(filename);
            }

        }
    }
}
