using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Ermes.Dataclasses;

namespace Ermes.API
{
    class ChatController
    {
        /*
         * Main functions:
         * GET, POST, PUT, DELETE
         */
        public static Chat GetChat(string id)
        {
            string response = MainController.Get("http://localhost:4000/api/chats/id/" + id);
            return JsonConvert.DeserializeObject<Chat>(response);
        }

        public static List<Chat> GetAllChats()
        {
            string response = MainController.Get("http://localhost:4000/api/chats");
            return JsonConvert.DeserializeObject<List<Chat>>(response);
        }

        public static string PostChat(Chat chat)
        {
            string chatJson = JsonConvert.SerializeObject(chat);
            StringContent content = new StringContent(chatJson, Encoding.UTF8, "application/json");
            string response = MainController.Post("http://localhost:4000/api/chats", content);
            return response;
        }

        public static string PutChat(Chat chat)
        {
            string chatJson = JsonConvert.SerializeObject(chat);
            StringContent content = new StringContent(chatJson, Encoding.UTF8, "application/json");
            return MainController.Put("http://localhost:4000/api/chats/id/", content);
        }

        public static string DeleteChat(string id)
        {
            return MainController.Delete("http://localhost:4000/api/chats/id/" + id);
        }
    }
}
