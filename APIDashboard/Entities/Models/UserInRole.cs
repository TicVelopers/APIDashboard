using System;
using System.Collections.Generic;

namespace APIDashboard.Entities.Models
{
    public partial class UserInRole
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
    }
}
