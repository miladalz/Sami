using Application.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService
{
    public static class RegisterLoggingService
    {
        public static void ConfigureLoggingService(this IServiceCollection service)
        {
            service.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
