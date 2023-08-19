using Application.Authentication;
using Application.BusinessServices;
using Application.Interfaces.Business;
using Infrastructure.Identity.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IPersonService, PersonService>();
        }
    }
}
