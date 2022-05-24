using System;
using System.Collections.Generic;
using System.Text;

namespace Ermes.Models
{
    class MessageModel
    {

        public string Username { get; set; }
        public string NameColor { get; set; }
        public string ImageSource { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsFromCurrentUser { get; set; }

    }
}
