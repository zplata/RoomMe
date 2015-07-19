using RoomMe.Webservice.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using RoomMe.Webservice.DataAccess.DAO;


namespace RoomMe.Webservice.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedData();
            System.Console.ReadLine();
        }

        static void SeedData()
        {
            var db = new RoomMeWebserviceContext();
            UserDAO uDAO = new UserDAO(db);

            var result =  uDAO.GetUserbyID(1);

        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10301/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/career/1");
                if (response.IsSuccessStatusCode)
                {
                    string jsonMessage;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    System.Console.WriteLine(jsonMessage);
                }
            }
        }
    }
}
