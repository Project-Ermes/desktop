using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Ermes.Dataclasses;

namespace Ermes.API
{
    class MessageController
    {
        public static Message GetMessage(string id)
        {
            string response = MainController.Get("http://localhost:4000/api/messages/id/" + id);
            return JsonConvert.DeserializeObject<Message>(response);
        }

        public static List<Message> GetAllMessages()
        {
            string response = MainController.Get("http://localhost:4000/api/messages");
            return JsonConvert.DeserializeObject<List<Message>>(response);
        }

        public static string PostMessage(Message message)
        {
            string messageJson = JsonConvert.SerializeObject(message);
            StringContent content = new StringContent(messageJson, Encoding.UTF8, "application/json");
            string response = MainController.Post("http://localhost:4000/api/messages", content);
            return response;
        }

        public static string PutMessage(Message message)
        {
            string messageJson = JsonConvert.SerializeObject(message);
            StringContent content = new StringContent(messageJson, Encoding.UTF8, "application/json");
            return MainController.Put("http://localhost:4000/api/messages/id/", content);
        }

        public static string DeleteMessage(string id)
        {
            return MainController.Delete("http://localhost:4000/api/messages/id/" + id);
        }
    }
}
