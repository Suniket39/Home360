using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Repositories;
using Home360.Infrastructure.Persistence;
using Home360.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Home360.Infrastructure
{
    public static class IntrastructureDIExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register infrastructure services here
            services.AddScoped<IHomeContextFactory, HomeContextFactory>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserManagerRepository, UserManagerRepository>();
            services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddScoped<IExpenseTransactionRepository, ExpenseTransactionRepository>();
            return services;
        }
    }
}
    