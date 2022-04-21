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
            using (HttpClient client = new HttpClient())
            {
                Uri endpoint = new Uri(url);
                HttpResponseMessage result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }

        public static string Post(string url, StringContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri endpoint = new Uri(url);
                HttpResponseMessage response = client.PostAsync(endpoint, content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public static string Put(string url, StringContent content)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri endpoint = new Uri(url);
                HttpResponseMessage response = client.PutAsync(endpoint, content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        public static string Delete(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri endpoint = new Uri(url);
                HttpResponseMessage response = client.DeleteAsync(endpoint).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}
