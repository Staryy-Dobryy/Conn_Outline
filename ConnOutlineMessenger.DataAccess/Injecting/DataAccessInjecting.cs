using ConnOutlineMessenger.DataAccess.Interfaces;
using ConnOutlineMessenger.DataAccess.Repositories;
using ConnOutlineMessenger.DBstur;
using ConnOutlineMessenger.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConnOutlineMessenger.BuisnessLogic.Injecting
{
    public static class DataAccessInjecting
    {
        public static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration["ConnectionString"]));
        }

        public static void UseDataBase(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<DataBaseContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
