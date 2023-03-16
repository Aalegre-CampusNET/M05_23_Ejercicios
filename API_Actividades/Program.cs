using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace API_Actividades
{

    public class Activity
    {
        public string activity;
        public string type;
        public int participants;
        public float price;
        public string link;
        public string key;
        public float accesibility;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            List<Activity> list = new List<Activity>();

            for (int i = 0; i < 100; i++)
            {
                System.Threading.Tasks.Task<HttpResponseMessage> result = client.GetAsync("https://www.boredapi.com/api/activity");

                string resultadoHttp = result.Result.Content.ReadAsStringAsync().Result;

                Activity actividad = new Activity();

                actividad = JsonConvert.DeserializeObject<Activity>(resultadoHttp);

                list.Add(actividad);
            }

            
        }
    }
}
