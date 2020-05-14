using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDashboard.Models.ModelsDTO
{
    public class UserDTO
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
