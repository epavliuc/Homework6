using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace HarryPotterApi
{
    public class Program
    {
        static void Main(string[] args)
        {
            HarryPotterP HPI = new HarryPotterP();
            HPI.HarryPApiArray("characters");
            
            for(int i=0; i < HPI.Response.Headers.Count;i++)
            {
                Console.WriteLine(HPI.Response.Headers[i].ToString());
            }
            Console.Read();
        }
    }
    public static class ApiConfig
    {
        public static string BaseUri = "https://www.potterapi.com/v1/";
        public static string ApiKey = "?key=$2a$10$4r0IHgAwqw7nkFw2jqQGS.NYuD7pLcstX/rhUC4TgO0Wa1uM3bmii";
        
    }

    public class HarryPotterP
    {
        public JObject HarryPotterResponsSingle { get; set; }
        public JArray HarryPotterResponsArray { get; set; }
        public IRestResponse Response { get; set; }
        public void HarryPApiSingle(string requesting)
        {
            string formaturl = ApiConfig.BaseUri + requesting + ApiConfig.ApiKey;
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            var client = new RestClient(formaturl);
            Response = client.Execute(request);

            //when i want to call all character list(when return, specify index of array)
            //JArray jsonArray = JArray.Parse(Response.Content);
            //HarryPotterRespons = JObject.Parse(jsonArray[0].ToString());

            HarryPotterResponsSingle = JObject.Parse(Response.Content);

        }

        public void HarryPApiArray(string requesting)
        {
            string formaturl = ApiConfig.BaseUri + requesting + ApiConfig.ApiKey;
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            var client = new RestClient(formaturl);
            Response = client.Execute(request);

            HarryPotterResponsArray = JArray.Parse(Response.Content);
        }

    }
}
