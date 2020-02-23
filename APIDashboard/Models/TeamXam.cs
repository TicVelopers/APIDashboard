using System;
using System.Collections.Generic;

namespace APIDashboard.Models
{
    public partial class TeamXam
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string GithubUser { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Team { get; set; }
    }
}
