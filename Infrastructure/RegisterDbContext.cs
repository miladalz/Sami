using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterDbContext
    {
        public static void AddDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<SamiDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
