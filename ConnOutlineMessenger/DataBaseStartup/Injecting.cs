using ConnOutlineMessenger.DBstur;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConnOutlineMessenger.DataBaseStartup
{
    public static class Injecting
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFcontext>(options => options.UseSqlServer(configuration["ConnectionString"]));
            services.AddScoped<EFcontext>();
        }
    }
}
