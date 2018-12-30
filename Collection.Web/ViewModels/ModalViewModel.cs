namespace Collection.Web.ViewModels
{
    public enum ModalSize
    {
        Small = 1,
        Medium = 2,
        Large = 3,
        ExtraLarge = 4
    };

    public class ModalViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public ModalSize Size { get; set; }

        public string OnConfirm { get; set; }
        public string OnClose { get; set; }
    }
}
