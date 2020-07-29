using System;
using System.Collections.Generic;

namespace APIDashboard.Entities.Models
{
    public partial class ChatConversation
    {
        public int? Id { get; set; }
        public string MessageSender { get; set; }
        public string MessageReceiver { get; set; }
        public string MessageText { get; set; }
        public DateTime? DateTime { get; set; }
        public string Status { get; set; }
    }
}
