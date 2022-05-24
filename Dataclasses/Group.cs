using System;
using System.Collections.Generic;
using System.Text;
using Ermes.Models;

namespace Ermes.Dataclasses
{
    class Group
    {
        public string _id;
        public string name;
        public string description;
        public string image;
        public User[] users;
        public Message[] messages;
        public DateTime createdAt;
        public DateTime updatedAt;

        public Group(string name, string description, string image, 
                    User[] users, Message[] messages)
        {
            this.name = name;
            this.description = description;
            this.image = image;
            this.users = users;
            this.messages = messages;
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public Group() { }
    }
}
