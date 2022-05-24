using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Ermes.API
{
    class MainController
    {
        public static string Get(string url)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(url).Result;
                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static string Post(string url, StringContent content)
        {
            using (var client = new HttpClient())
            {
                var result = client.PostAsync(url, content).Result;
                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static string Put(string url, StringContent content)
        {
            using (var client = new HttpClient())
            {
                var result = client.PutAsync(url, content).Result;
                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static string Delete(string url)
        {
            using (var client = new HttpClient())
            {
                var result = client.DeleteAsync(url).Result;
                return result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
