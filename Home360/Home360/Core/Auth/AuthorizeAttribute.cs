using Home360.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Home360.API.Core.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _screenCode;
        private readonly string _access;
        private readonly IList<string> _roles;

        public AuthorizeAttribute(string screenCode = null, string access = null, params string[] roles)
        {
            _screenCode = screenCode;
            _access = access;
            _roles = roles ?? new string[] { };
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            bool isAccess = true;
            var userAccessInfo = context.HttpContext.Items["UserAccess"];
            if(userAccessInfo == null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.HttpContext.Response.Headers["X-reason"] = "This account is not authorized to access.";
                context.Result = new JsonResult(new
                {
                    message = "This account is not authorised to access."
                });
                return;
            }

            var userAccess = (List<UserScreenAccessDto>)userAccessInfo;
            if (userAccess == null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.HttpContext.Response.Headers["X-reason"] = "This account is not authorized to access.";
                context.Result = new JsonResult(new
                {
                    message = "This account is not authorised to access."
                });
            }
            if (_screenCode != null)
                isAccess = userAccess.Any(x => x.ScreenCode == _screenCode && CheckAccess(x, _access));

            if (userAccess == null || !isAccess)
            {
                context.Result = new JsonResult(new { message = "Unauthorized"}){ StatusCode = StatusCodes.Status401Unauthorized};
            }
        }

        private bool CheckAccess(UserScreenAccessDto dto, string access = null)
        {
            if (access == "C")
                return dto.CanCreate;
            else if ( access == "U")
                return dto.CanUpdate;
            else if (access == "D")
                return dto.CanDeactivate;
            else if (access == "R")
                return dto.CanRead;
            else
                 return false;
        }
    }
}
