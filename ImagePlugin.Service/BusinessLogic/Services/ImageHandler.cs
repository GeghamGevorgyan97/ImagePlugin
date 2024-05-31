using static System.Net.Mime.MediaTypeNames;

namespace ImagePlugin.Service.BusinessLogic.Services
{
    public class ImageHandler
    {
        private List<Image> images;
        private PluginManager pluginManager;

        public ImageHandler()
        {
            images = new List<Image>();
            pluginManager = new PluginManager();
        }

        public void AddImage(Image image)
        {
            images.Add(image);
        }

        public void ApplyPlugins(string imageName, List<PluginOperation> operations)
        {
            var image = images.FirstOrDefault(img => img.Name == imageName);
            if (image == null)
                throw new Exception("Image not found");

            foreach (var operation in operations)
            {
                var plugin = pluginManager.GetPlugin(operation.PluginName);
                plugin.Apply(image, operation.Parameters);
            }
        }
    }
}
