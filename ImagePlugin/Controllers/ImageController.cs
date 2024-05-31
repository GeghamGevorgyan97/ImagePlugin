using ImagePlugin.Models;
using ImagePlugin.Models.Enums;
using ImagePlugin.Service.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Drawing;
using System.Reflection;

namespace ImagePlugin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IBlurPlugin _blurService;
        private readonly IResizePlugin _resizeService;
        private readonly IGrayscalePlugin _grayscaleService;

        public ImageController(IGrayscalePlugin grayscaleService, IResizePlugin resizeService, IBlurPlugin blurService)
        {
            _grayscaleService = grayscaleService;
            _resizeService = resizeService;
            _blurService = blurService;
        }

        [HttpPost("Resize")]
        public ActionResult<IEnumerable<byte>> ResizeImage([FromForm] ResizeModel model)
        {
            if (model.File == null || model.File.Length <= 0)
            {
                return BadRequest("Invalid input parameters.");
            }

            using (var memoryStream = new MemoryStream())
            {
                model.File.CopyTo(memoryStream);

                var imageByteArray = memoryStream.ToArray();

                var result = _resizeService.Resize(imageByteArray, model.Width, model.Height);

                return Ok(result);
            }
        }

        [HttpPost("Grayscale")]
        public ActionResult<IEnumerable<byte>> GrayscaleImage([FromForm] GrayscaleModel model)
        {
            if (model.File == null || model.File.Length <= 0)
            {
                return BadRequest("Invalid input parameters.");
            }

            using (var memoryStream = new MemoryStream())
            {
                model.File.CopyTo(memoryStream);

                var imageByteArray = memoryStream.ToArray();

                var result = _grayscaleService.Grayscale(imageByteArray, model.Width, model.Height);

                return Ok(result);
            }
        }

        [HttpPost("Blur")]
        public ActionResult<IEnumerable<byte>> BlurImage([FromForm] BlurModel model)
        {
            if (model.File == null || model.File.Length <= 0)
            {
                return BadRequest("Invalid input parameters.");
            }

            using (var memoryStream = new MemoryStream())
            {
                model.File.CopyTo(memoryStream);

                var imageByteArray = memoryStream.ToArray();

                var result = _blurService.Blur(imageByteArray, model.Width, model.Height, model.BytesPerPixel);

                return Ok(result);
            }
        }
    }
}
