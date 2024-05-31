
namespace ImagePlugin.Service.BusinessLogic.Interfaces
{
    public interface IBlurPlugin
    {
        byte[] Blur(byte[] pixels, int width, int height, int bytesPerPixel);
    }
}
