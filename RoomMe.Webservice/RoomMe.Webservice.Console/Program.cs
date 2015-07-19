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
            RunAsync().Wait();
            System.Console.ReadLine();
        }

        static void SeedData()
        {

            var db = new RoomMeWebserviceContext();

            UserDAO uDAO = new UserDAO(db);

            var p1 = new Preferences
            {
                Gender = Gender.Male,
                Age = 40,
                UpperPriceLimit = 600,
                LowerPriceLimit = 300,
            };

            var p2 = new Preferences
            {
                Gender = Gender.Male,
                Age = 40,
                UpperPriceLimit = 1500,
                LowerPriceLimit = 800,
            };

            var p3 = new Preferences
            {
                Gender = Gender.Male,
                Age = 30,
                UpperPriceLimit = 700,
                LowerPriceLimit = 200,
            };

            var p4 = new Preferences
            {
                Gender = Gender.Male,
                Age = 20,
                UpperPriceLimit = 1200,
                LowerPriceLimit = 400,
            };

            var p5 = new Preferences
            {
                Gender = Gender.Female,
                Age = 25,
                UpperPriceLimit = 1100,
                LowerPriceLimit = 700,
            };

            var p6 = new Preferences
            {
                Gender = Gender.Male,
                Age = 25,
                UpperPriceLimit = 10000,
                LowerPriceLimit = 200,
            };

            var p7 = new Preferences
            {
                Gender = Gender.Female,
                Age = 20,
                UpperPriceLimit = 400,
                LowerPriceLimit = 100,
            };

            var p8 = new Preferences
            {
                Gender = Gender.Male,
                Age = 30,
                UpperPriceLimit = 1000,
                LowerPriceLimit = 600,
            };

            var p9 = new Preferences
            {
                Gender = Gender.Female,
                Age = 20,
                UpperPriceLimit = 1500,
                LowerPriceLimit = 400,
            };

            var p10 = new Preferences
            {
                Gender = Gender.Male,
                Age = 20,
                UpperPriceLimit = 500,
                LowerPriceLimit = 0,
            };

            var prefs = new List<Preferences> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };

            db.Preferences.AddRange(prefs);

            var c1 = new Career
            {
                Company = "USA",
                JobTitle = "Former Prez"
            };

            var c2 = new Career
            {
                Company = "USA",
                JobTitle = "Prez"
            };

            var c3 = new Career
            {
                Company = "Rebels",
                JobTitle = "Smuggler"
            };

            var c4 = new Career
            {
                Company = "Cali",
                JobTitle = "Governor"
            };

            var c5 = new Career
            {
                Company = "Columbia Records",
                JobTitle = "Diva"
            };

            var c6 = new Career
            {
                Company = "Wayne Industries",
                JobTitle = "The Batman"
            };

            var c7 = new Career
            {
                Company = "7 seas",
                JobTitle = "Pirate"
            };

            var c8 = new Career
            {
                Company = "WBA",
                JobTitle = "Pigeon Enthusiast"
            };

            var c9 = new Career
            {
                Company = "Republic Records",
                JobTitle = "Donut Terrorist"
            };

            var c10 = new Career
            {
                Company = "7 Kingdoms",
                JobTitle = "Hand of the King"
            };

            var careers = new List<Career> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 };

            db.Careers.AddRange(careers);




            var u1 = new User
            {
                Name = "Abraham Lincoln", 
                PhoneNumber = "815-555-1865", 
                Age = 50, 
                Gender = Gender.Male, 
                Email = "Yankee4life@gmail.com", 
                Status = Status.NeedsHousingAndRoommate,
			    Bio = "Going to see a play tonight, hope it goes off with a bang.",
                FavoritedUserIDs = null,
                Preferences = p1
            };

            db.Users.Add(u1);

            var u2 = new User
            {
                Name = "Barack Obama",
                PhoneNumber = "815-555-8193",
                Age = 53,
                Gender = Gender.Male,
                Email = "Daprez@whitehouse.gov",
                Status = Status.NeedsHousingAndRoommate,
                Bio = "2 TERMS!!! 'Bout to leave da white house, need a new crib to chill in",
                FavoritedUserIDs = null,
                Preferences = p2
            };
            db.Users.Add(u2);

            var u3 = new User
            {
                Name = "Han Solo",
                PhoneNumber = "630-555-1324",
                Age = 42,
                Gender = Gender.Male,
                Email = "ScruffyNerfHerder@outlook.com",
                Status = Status.HasVacancy,
                Bio = "I have one very large...Dog. I have a very bad feeling about this...",
                FavoritedUserIDs = null,
                Preferences =  p3
            };
            db.Users.Add(u3);

            var u4 = new User
            {
                Name = "Arnold Schwarzenegger",
                PhoneNumber = "916-555-9769",
                Age = 67,
                Gender = Gender.Male,
                Email = "Governator@california.gov",
                Status = Status.NeedsHousingAndRoommate,
                Bio = "I need a roommate who can rival my level of swole. Hasta la Vista, Baby.",
                FavoritedUserIDs = null,
                Preferences = p4
            };
            db.Users.Add(u4);

            var u5 = new User
            {
                Name = "Beyonce Knowles",
                PhoneNumber = "310-555-1040",
                Age = 33,
                Gender = Gender.Female,
                Email = "QueenB@hotmail.com",
                Status = Status.NeedsRoommateOnly,
                Bio = "I put all my old Roommate's things in a box to the left. He should have put a ring on it",
                FavoritedUserIDs = null,
                Preferences = p5
            };
            db.Users.Add(u5);

            var u6 = new User
            {
                Name = "The Batman",
                PhoneNumber = "670-555-3123",
                Age = 40,
                Gender = Gender.Male,
                Email = "NotBruceWayne@WayneIndustries.com",
                Status = Status.HasVacancy,
                Bio = "I am The Batman. The available Room is cold, clammy and full of bats.",
                FavoritedUserIDs = null,
                Preferences = p6
            };
            db.Users.Add(u6);

            var u7 = new User
            {
                Name = "Blackbeard",
                PhoneNumber = "480-555-3459",
                Age = 20,
                Gender = Gender.Male,
                Email = "Arrrrrrgghh@piratebay.se",
                Status = Status.HasVacancy,
                Bio = "Shiver me timbers! I be havin an open room on me poopdeck",
                FavoritedUserIDs = null,
                Preferences = p7
            };
            db.Users.Add(u7);

            var u8 = new User
            {
                Name = "Mike Tyson",
                PhoneNumber = "784-555-1384",
                Age = 30,
                Gender = Gender.Male,
                Email = "IronMike@yahoo.com",
                Status = Status.HasVacancy,
                Bio = "Looking for roommates who can lend an ear. Must be okay with my Pigeon Collection",
                FavoritedUserIDs = null,
                Preferences = p8
            };
            db.Users.Add(u8);

            var u9 = new User
            {
                Name = "Ariana Grande",
                PhoneNumber = "654-555-1234",
                Age = 22,
                Gender = Gender.Female,
                Email = "1lasttime@msn.com",
                Status = Status.NeedsHousingAndRoommate,
                Bio = "Zach is bae, Zach is life.",
                FavoritedUserIDs = null,
                Preferences = p9
            };
            db.Users.Add(u9);

            var u10 = new User
            {
                Name = "Ned Stark",
                PhoneNumber = "132-555-1567",
                Age = 46,
                Gender = Gender.Male,
                Email = "winteriscoming@aol.com",
                Status = Status.HasVacancy,
                Bio = "Just trying to get ahead in life. Trying to fill a vacancy in my keep, Winterfell",
                FavoritedUserIDs = null,
                Preferences = p10
            };
            db.Users.Add(u10);

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
