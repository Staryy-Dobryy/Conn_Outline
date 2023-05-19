using ConnOutlineMessenger.BuisnessLogic.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Services;
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
        }
    }
}
