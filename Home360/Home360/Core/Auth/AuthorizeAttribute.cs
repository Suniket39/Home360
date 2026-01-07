using Microsoft.AspNetCore.Mvc.Filters;

namespace Home360.API.Core.Auth
{
    public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
        }
    }
}
