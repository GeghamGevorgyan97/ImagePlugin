using ImagePlugin.Service.BusinessLogic.Interfaces;
using System.Drawing.Imaging;
using System.Drawing;

namespace ImagePlugin.Service.BusinessLogic.Services
{
    public class GrayscalePlugin : IGrayscalePlugin
    {
        public Bitmap Grayscale(byte[] byteArray, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 3;
                    byte r = byteArray[index];
                    byte g = byteArray[index + 1];
                    byte b = byteArray[index + 2];

                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);

                    bitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return bitmap;
        }
    }
}
