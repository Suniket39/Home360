using Home360.API.Core.Middleware;

namespace Home360.API.Core.Extension
{
    public static class ApiDIExtension
    {
       public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Register API services here
            //Miidlewares
            services.AddScoped<JwtHandlerMiddleware>();

            return services;
        }
    }
}
