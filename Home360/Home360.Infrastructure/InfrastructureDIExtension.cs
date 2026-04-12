using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Repositories;
using Home360.Infrastructure.Persistence;
using Home360.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Home360.Infrastructure
{
    public static class InfrastructureDIExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register infrastructure services here
            services.AddDbContext<HomeDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DataSQLContext")));
            
            services.AddScoped<IHomeContextFactory, HomeContextFactory>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserManagerRepository, UserManagerRepository>();
            services.AddScoped<IRoleMasterRepository, RoleMasterRepository>();
            services.AddScoped<IScreenMasterRepository, ScreenMasterRepository>();
            services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddScoped<IExpenseTransactionRepository, ExpenseTransactionRepository>();
            return services;
        }
    }
}
    