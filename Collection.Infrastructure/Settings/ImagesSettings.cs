namespace Collection.Infrastructure.Settings
{
    public class LocalImages
    {
        public string Source { get; set; }
        public string Thumbs { get; set; }
    };

    public class ImagesSettings
    {
        public LocalImages Local { get; set; }
    }
}