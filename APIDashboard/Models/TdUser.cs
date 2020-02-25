using System;
using System.Collections.Generic;

namespace APIDashboard.Models
{
    public partial class TdUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ApiKey { get; set; }
        public string Status { get; set; }
    }
}
