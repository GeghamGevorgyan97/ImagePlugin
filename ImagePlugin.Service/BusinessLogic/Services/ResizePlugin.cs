using ImagePlugin.Service.BusinessLogic.Interfaces;
using System.Drawing;
using Image = System.Drawing.Image;

namespace ImagePlugin.Service.BusinessLogic.Services
{
    public class ResizePlugin : IResizePlugin
    {
        public string Name => "resize";

        public byte[] Resize(byte[] imageBytes, int width, int height)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                using (var originalImage = Image.FromStream(ms))
                {
                    using (var resizedBitmap = new Bitmap(width, height))
                    {
                        using (var graphics = Graphics.FromImage(resizedBitmap))
                        {
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                            graphics.DrawImage(originalImage, 0, 0, width, height);
                        }

                        using (var msResized = new MemoryStream())
                        {
                            resizedBitmap.Save(msResized, originalImage.RawFormat);
                            return msResized.ToArray();
                        }
                    }
                }
            }
        }
    }
}
