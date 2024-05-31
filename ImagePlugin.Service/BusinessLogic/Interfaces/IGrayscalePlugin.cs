using System.Drawing;

namespace ImagePlugin.Service.BusinessLogic.Interfaces
{
    public interface IGrayscalePlugin
    {
        Bitmap Grayscale(byte[] byteArray, int width, int height);
    }
}
