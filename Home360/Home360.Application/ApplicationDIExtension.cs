using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Application.Interfaces.Services.BillTracker;
using Home360.Application.Services;
using Home360.Application.Services.BillTracker;
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
            services.AddScoped<IRoleAccessManagerService, RoleAccessManagerService>();

            services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
            services.AddScoped<IExpenseTransactionService, ExpenseTransactionService>();

            services.AddScoped<IGroceryItemService, GroceryItemService>();
            services.AddScoped<IGroceryInventoryService, GroceryInventoryService>();
            services.AddScoped<IMonthlyCartService, MonthlyCartService>();

            services.AddScoped<IBillsService, BillService>();
            return services;
        }
    }
}
