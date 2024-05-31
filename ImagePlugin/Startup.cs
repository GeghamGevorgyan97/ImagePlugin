using ImagePlugin.Service.BusinessLogic.Interfaces;
using ImagePlugin.Service.BusinessLogic.Services;

namespace ImagePlugin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IBlurPlugin, BlurPlugin>();
            services.AddScoped<IGrayscalePlugin, GrayscalePlugin>();
            services.AddScoped<IResizePlugin, ResizePlugin>();
            services.AddScoped<IPluginManager, PluginManager>();
        }
    }
}
