using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Ermes.Dataclasses;

namespace Ermes.API
{
    class UserController
    {

        /*
         * Main functions:
         * GET, POST, PUT, DELETE
         */
        public static User GetUser(string id)
        {
            string response = MainController.Get("http://localhost:4000/api/users/id/" + id);
            return JsonConvert.DeserializeObject<User>(response);
        }

        public static User FindUserByUsername(string username)
        {
            string response = MainController.Get("http://localhost:4000/api/users/username/" + username);
            return JsonConvert.DeserializeObject<User>(response);
        }

        public static User FindUserByEmail(string email)
        {
            string response = MainController.Get("http://localhost:4000/api/users/email/" + email);
            return JsonConvert.DeserializeObject<User>(response);
        }

        public static List<User> GetAllUsers()
        {
            string response = MainController.Get("http://localhost:4000/api/users");
            return JsonConvert.DeserializeObject<List<User>>(response);
        }

        public static string PostUser(User user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            string response = MainController.Post("http://localhost:4000/api/users", content);
            return response;
        }

        public static string PutUser(User user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");
            return MainController.Put("http://localhost:4000/api/users/id/", content);
        }

        public static string DeleteUser(string id)
        {
            return MainController.Delete("http://localhost:4000/api/users/id/" + id);
        }
        
    }
}
