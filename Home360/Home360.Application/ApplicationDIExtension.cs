using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Home360.Application
{
    public static class ApplicationDIExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleMasterService, RoleMasterService>();
            services.AddScoped<IScreenMasterService, ScreenMasterService>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            services.AddScoped<IExpenseTransactionService, ExpenseTransactionService>();
            return services;
        }
    }
}
