using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Configuration;

namespace APIDashboard.Attributes
{
    public class CustomRoleProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string User, string Role) {
            throw new NotImplementedException();
        }
    }
}
