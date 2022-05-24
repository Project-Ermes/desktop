using System;
using System.Collections.Generic;
using System.Text;

namespace Ermes.Dataclasses
{
    class Message
    {
        public string origin;
        public string from;
        public string content;
        public DateTime createdAt;
        public DateTime updatedAt;

        public Message(string origin, string from, string content)
        {
            this.origin = origin;
            this.from = from;
            this.content = content;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public Message() { }
    }
}
