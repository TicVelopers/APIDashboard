using System;
using System.Collections.Generic;

namespace APIDashboard.Entities.Models
{
    public partial class ChatUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
    }
}
