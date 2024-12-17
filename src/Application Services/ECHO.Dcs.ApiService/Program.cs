using NLog;
using NLog.Web;

namespace ECHO.Maint.ApiService;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug($"init {nameof(Program.Main)}");
        try
        {
            var webApiAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var serviceInfo = SharedKernel.ApiService.ServiceInfo.CreateInstance(webApiAssembly);

            var app = WebApplication
                .CreateBuilder(args)
                .ConfigureDcsDefault(serviceInfo)
                .Build();

            app.UseDcs();

            await app
                .ChangeThreadPoolSettings()
                .UseRegistrationCenter()
                .RunAsync();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}