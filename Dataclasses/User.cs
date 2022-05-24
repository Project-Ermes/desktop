using System;
using System.Collections.Generic;
using System.Text;

namespace Ermes.Dataclasses
{
    public class User
    {
        public string _id;
        public string username;
        public string password;
        public string email;
        public string name;
        public string surname;
        public DateTime birthDate;
        public string image;
        public int status;
        public string description;
        public string accentColor;
        public string[] chats;
        public string[] groups;
        public string[] blockedUsers;
        public DateTime createdAt;
        public DateTime updatedAt;

        public User(string username, string password, string email, string name,
                    string surname, DateTime birthDate)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
            this.image = "";
            this.status = 0;
            this.description = "";
            this.accentColor = "";
            this.chats = Array.Empty<string>();
            this.groups = Array.Empty<string>();
            this.blockedUsers = Array.Empty<string>();
            this.createdAt = DateTime.Now;
            this.updatedAt = DateTime.Now;
        }

        public User() { }
    }
}

