using ConnOutlineMessenger.DBstur;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConnOutlineMessenger.DataBaseStartup
{
    public static class Injecting
    {
        public static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
            services.AddScoped<DataBaseContext>();
        }
        public static void UseDataBase(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<DataBaseContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
