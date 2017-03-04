using ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables
{
    public class Globals
    {
        public static string toysDirectory = "img\\toys";
        public static string toysThumbnailsDirectory = toysDirectory + "\\thumb";
        public static string thumbnailSufix = ".jpg";
        public static string imageSufix = "_l.jpg";

        public static Size ThumbSize = new Size()
        {
            Height = 320,
            Width = 400
        };
    }
}
