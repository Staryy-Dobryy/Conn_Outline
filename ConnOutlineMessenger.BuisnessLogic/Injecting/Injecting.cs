using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Services.Realization;
using ConnOutlineMessenger.BuisnessLogic.SignalR;
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
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IFriendsService, FriendsService>();
            services.AddAutoMapper(typeof(AppMappingProfile));
        }
    }
}
