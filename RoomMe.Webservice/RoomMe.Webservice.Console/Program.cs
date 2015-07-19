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


            var t1 = new Tag { Name = "Politics" };
            var t2 = new Tag { Name = "Theater" };
            var t3 = new Tag { Name = "Call of Duty" };
            var t4 = new Tag { Name = "Abolition" };
            var t5 = new Tag { Name = "Traveling" };
            var t6 = new Tag { Name = "Democratic Party" };
            var t7 = new Tag { Name = "Swag" };
            var t8 = new Tag { Name = "Space" };
            var t9 = new Tag { Name = "Dogs" };
            var t10 = new Tag { Name = "Cats" };
            var t11 = new Tag { Name = "Lifting" };
            var t12 = new Tag { Name = "Crushing Your Enemies" };
            var t13 = new Tag { Name = "John Connor" };
            var t14 = new Tag { Name = "Singing" };
            var t15 = new Tag { Name = "Dancing" };
            var t16 = new Tag { Name = "Crime Fighting" };
            var t17 = new Tag { Name = "Soap Opera" };
            var t18 = new Tag { Name = "Bats" };
            var t19 = new Tag { Name = "Wayne Industries" };
            var t20 = new Tag { Name = "Online Piracy" };
            var t21 = new Tag { Name = "Sailing" };
            var t22 = new Tag { Name = "Rum" };
            var t23 = new Tag { Name = "Boxing" };
            var t24 = new Tag { Name = "Ears" };
            var t25 = new Tag { Name = "Pigeons" };
            var t26 = new Tag { Name = "Winter" };
            var t27 = new Tag { Name = "Game of Thrones" };
            var t28 = new Tag { Name = "Jousting" };
            var t29 = new Tag { Name = "Defending M'lady's Honor" };
            var t30 = new Tag { Name = "Republican Party" };
            var t31 = new Tag { Name = "Lasers" };
            var t32 = new Tag { Name = "Donuts" };

            var tags = new List<Tag> { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32 };

            db.Tags.AddRange(tags);

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
