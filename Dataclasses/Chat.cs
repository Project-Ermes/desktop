using System;
using System.Collections.Generic;
using System.Text;
using Ermes.Models;

namespace Ermes.Dataclasses
{
    class Chat
    {
        public string _id;
        public User[] users;
        public Message[] messages;
        public DateTime createdAt;
        public DateTime updatedAt;

        public Chat(User[] users, Message[] messages)
        {
            this.users = users;
            this.messages = messages;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public Chat() { }
    }
}
