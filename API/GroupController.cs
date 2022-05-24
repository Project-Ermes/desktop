using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Ermes.Dataclasses;

namespace Ermes.API
{
    class GroupController
    {
        /*
         * Main functions:
         * GET, POST, PUT, DELETE
         */
        public static Group GetGroup(string id)
        {
            string response = MainController.Get("http://localhost:4000/api/groups/id/" + id);
            return JsonConvert.DeserializeObject<Group>(response);
        }

        public static List<Group> GetAllGroups()
        {
            string response = MainController.Get("http://localhost:4000/api/groups");
            return JsonConvert.DeserializeObject<List<Group>>(response);
        }

        public static string PostGroup(Group group)
        {
            string groupJson = JsonConvert.SerializeObject(group);
            StringContent content = new StringContent(groupJson, Encoding.UTF8, "application/json");
            string response = MainController.Post("http://localhost:4000/api/groups", content);
            return response;
        }

        public static string PutGroup(Group group)
        {
            string groupJson = JsonConvert.SerializeObject(group);
            StringContent content = new StringContent(groupJson, Encoding.UTF8, "application/json");
            return MainController.Put("http://localhost:4000/api/groups/id/", content);
        }

        public static string DeleteGroup(string id)
        {
            return MainController.Delete("http://localhost:4000/api/groups/id/" + id);
        }
    }
}
