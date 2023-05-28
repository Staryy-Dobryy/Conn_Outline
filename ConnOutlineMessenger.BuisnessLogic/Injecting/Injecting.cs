using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Services.Realization;
using ConnOutlineMessenger.DBstur;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConnOutlineMessenger.BuisnessLogic.Injecting
{
    public static class BuisnessLogicInjector
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IJwtCreationService, JwtCreationService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddAutoMapper(typeof(AppMappingProfile));
        }
    }
}
