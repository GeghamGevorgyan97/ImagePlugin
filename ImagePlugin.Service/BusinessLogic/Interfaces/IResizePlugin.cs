using static System.Net.Mime.MediaTypeNames;

namespace ImagePlugin.Service.BusinessLogic.Interfaces
{
    public interface IResizePlugin
    {
        byte[] Resize(byte[] imageBytes, int width, int height);
    }
}
