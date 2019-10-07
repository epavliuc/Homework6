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
            HPI.HarryPApi(ApiConfig.BaseUri, "characters",ApiConfig.ApiKey);
            
        }
    }
    public static class ApiConfig
    {
        public static string BaseUri = "https://www.potterapi.com/v1/";
        public static string ApiKey = "?key=$2a$10$4r0IHgAwqw7nkFw2jqQGS.NYuD7pLcstX/rhUC4TgO0Wa1uM3bmii";
        
    }

    public class HarryPotterP
    {
        public JObject HarryPotterRespons { get; set; }

        public JObject HarryPApi(string url, string requesting, string key)
        {
            string formaturl = url + requesting + key;
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            var client = new RestClient(formaturl);
            IRestResponse response = client.Execute(request);

            //when i want to call all character list(when return, specify index of array)
            //JArray jsonArray = JArray.Parse(response.Content);
            //HarryPotterRespons = JObject.Parse(jsonArray[0].ToString());

            HarryPotterRespons = JObject.Parse(response.Content);

            return HarryPotterRespons;
        }

    }
}
