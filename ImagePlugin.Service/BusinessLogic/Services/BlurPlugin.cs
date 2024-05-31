using ImagePlugin.Service.BusinessLogic.Interfaces;

namespace ImagePlugin.Service.BusinessLogic.Services
{
    public class BlurPlugin : IBlurPlugin
    {
        public byte[] Blur(byte[] pixels, int width, int height, int bytesPerPixel)
        {
            byte[] result = new byte[pixels.Length];
            int blurSize = 5;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int r = 0, g = 0, b = 0;
                    int blurPixelCount = 0;

                    for (int ky = -blurSize; ky <= blurSize; ky++)
                    {
                        for (int kx = -blurSize; kx <= blurSize; kx++)
                        {
                            int pixelX = x + kx;
                            int pixelY = y + ky;

                            if (pixelX >= 0 && pixelX < width && pixelY >= 0 && pixelY < height)
                            {
                                int offset = (pixelY * width + pixelX) * bytesPerPixel;
                                r += pixels[offset + 2];
                                g += pixels[offset + 1];
                                b += pixels[offset];
                                blurPixelCount++;
                            }
                        }
                    }

                    int currentOffset = (y * width + x) * bytesPerPixel;
                    result[currentOffset] = (byte)(b / blurPixelCount);
                    result[currentOffset + 1] = (byte)(g / blurPixelCount);
                    result[currentOffset + 2] = (byte)(r / blurPixelCount);
                    if (bytesPerPixel == 4)
                    {
                        result[currentOffset + 3] = pixels[currentOffset + 3];
                    }
                }
            }

            return result;
        }
    }
}
