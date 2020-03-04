using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIDashboard.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RolesAuth : AuthorizeAttribute, IAuthorizationFilter
    {
        

        public string[] AuthRoles;
        public RolesAuth(params string[] Roles)
        {
            this.AuthRoles = Roles;
        }

       

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                
                return;
            }

            //var someService = context.HttpContext.RequestServices.GetRequiredService<DBAPIFUELSContext>();
            //someService.UserInRole.Where(w=>w.RoleName == getRoles && w.UserName == context.HttpContext.User.Identity.Name).Any()
            var someServices = context.HttpContext.RequestServices.GetRequiredService<CustomRoleProvider>();
            bool IsInRole = false;
            foreach (var getRoles in AuthRoles)
            {
                var IsUserInRole = someServices.IsUserInRole(context.HttpContext.User.Identity.Name, getRoles);
                if (IsUserInRole)
                {
                     IsInRole = true;
                }

            }

            if (!IsInRole) {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
           
        }
    }
}
