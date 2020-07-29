using System;
using System.Collections.Generic;

namespace APIDashboard.Entities.Models
{
    public partial class ChatFriendList
    {
        public int? Id { get; set; }
        public string NumberMain { get; set; }
        public string NumberFriend { get; set; }
        public string Estatus { get; set; }
    }
}
