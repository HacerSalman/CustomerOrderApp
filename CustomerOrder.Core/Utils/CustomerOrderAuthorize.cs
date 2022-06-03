using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CustomerOrderApp.Data.Enums;
using System.Security.Claims;

namespace CustomerOrderApp.Core.Utils
{
    public sealed class CustomerOrderAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomerOrderAuthorizeAttribute(params Permission.Values[] claim) : base(typeof(CustomerOrderAuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class CustomerOrderAuthorizeFilter : IAuthorizationFilter
    {
        readonly Permission.Values[] _claim;

        public CustomerOrderAuthorizeFilter(params Permission.Values[] claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (IsAuthenticated)
            {
                bool flagClaim = false;
                foreach (var item in _claim)
                {
                    if (context.HttpContext.User.HasClaim(ClaimTypes.Role, item.ToString()))
                        flagClaim = true;
                }
                if (!flagClaim)
                    context.Result = new UnauthorizedResult();

            }
            else
            {
                context.Result = new UnauthorizedResult();

            }
        }
    }
}
