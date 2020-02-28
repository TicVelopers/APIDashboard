using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDashboard.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RolesAuth : AuthorizeAttribute
    {
        private CustomRoleProvider RProvider = new CustomRoleProvider();
        public string[] AuthRoles;
        public RolesAuth(params string[] Roles)
        {
            this.AuthRoles = Roles;
        }
        protected bool AuthorizeCore(HttpContext httpContext)
        {
            bool IsInRole = false;

            foreach (var getRoles in AuthRoles)
            {
                if (RProvider.IsUserInRole(httpContext.User.Identity.Name.ToString(), getRoles))
                {
                    IsInRole = true;
                }

            }

            return IsInRole;
        }
    }
}
