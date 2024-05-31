namespace ImagePlugin.Models
{
    public class ImagePluginBaseModel
    {
        public IFormFile File { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
