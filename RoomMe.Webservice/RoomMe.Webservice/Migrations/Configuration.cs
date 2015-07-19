namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RoomMe.Webservice.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomMe.Webservice.Models.RoomMeWebserviceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomMe.Webservice.Models.RoomMeWebserviceContext context)
        {

            var l1 = new Location
            {
                LocationID = 1,
                Latitude = 39.0354776,
                Longitude = -94.5829717
            };

            var l2 = new Location
            {
                LocationID = 2,
                Latitude = 39.1024547,
                Longitude = -94.5990768
            };

            var l3 = new Location
            {
                LocationID = 3,
                Latitude = 39.0354776,
                Longitude = -94.5829717
            };

            var l4 = new Location
            {
                LocationID = 4,
                Latitude = 39.1024547,
                Longitude = -94.5990768
            };

            var l5 = new Location
            {
                LocationID = 5,
                Latitude = 39.0280185,
                Longitude = -94.5740019
            };

            var l6 = new Location
            {
                LocationID = 6,
                Latitude = 39.0826589,
                Longitude = -94.5824462
            };

            var locations = new List<Location> { l1, l2, l3, l4, l5, l6 };
            context.Locations.AddOrUpdate(x => x.LocationID, l1, l2, l3, l4, l5, l6);
            
            var h1 = new Housing
            {
                Name = "Millenium Falcon",
                Address = "10236 Marion Park Drive, Kansas City, MO. 64137",
                LocationID = l1.LocationID
            };

            var h2 = new Housing
            {
                Name = "Beyonce's Crib",
                Address = "Roanoke Rd Kansas City, MO. 64111",
                LocationID = l2.LocationID
            };

            var h3 = new Housing
            {
                Name = "Wayne Manor",
                Address = "5050 Oak Street, Kansas City, MO. 64112",
                LocationID = l3.LocationID
            };

            var h4 = new Housing
            {
                Name = "Wayne Manor",
                Address = "1217 Union Avenue, Kansas City, MO. 64101",
                LocationID = l4.LocationID
            };

            var h5 = new Housing
            {
                Name = "Queen Anne's Revenge",
                Address = "5424 Troost Avenue, Kansas City, MO. 64110",
                LocationID = l5.LocationID
            };

            var h6 = new Housing
            {
                Name = "Winterfell",
                Address = "2450 Grand Boulevard, Kansas City, MO. 64108",
                LocationID = l6.LocationID
            };

            var housings = new List<Housing> { h1, h2, h3, h4, h5, h6 };
            context.Housings.AddOrUpdate(x => x.Address, h1, h2, h3, h4, h5, h6);

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

            context.Tags.AddOrUpdate(x => x.Name,
                t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20, t21, t22, t23, t24, t25, t26, t27, t28, t29, t30, t31, t32
                );

            var p1 = new Preferences
            {
                PreferencesID = 1,
                Gender = Gender.Male,
                Age = 40,
                UpperPriceLimit = 600,
                LowerPriceLimit = 300,
            };

            var p2 = new Preferences
            {
                PreferencesID = 2,
                Gender = Gender.Male,
                Age = 40,
                UpperPriceLimit = 1500,
                LowerPriceLimit = 800,
            };

            var p3 = new Preferences
            {
                PreferencesID = 3,
                Gender = Gender.Male,
                Age = 30,
                UpperPriceLimit = 700,
                LowerPriceLimit = 200,
            };

            var p4 = new Preferences
            {
                PreferencesID = 4,
                Gender = Gender.Male,
                Age = 20,
                UpperPriceLimit = 1200,
                LowerPriceLimit = 400,
            };

            var p5 = new Preferences
            {
                PreferencesID = 5,
                Gender = Gender.Female,
                Age = 25,
                UpperPriceLimit = 1100,
                LowerPriceLimit = 700,
            };

            var p6 = new Preferences
            {
                PreferencesID = 6,
                Gender = Gender.Male,
                Age = 25,
                UpperPriceLimit = 10000,
                LowerPriceLimit = 200,
            };

            var p7 = new Preferences
            {
                PreferencesID = 7,
                Gender = Gender.Female,
                Age = 20,
                UpperPriceLimit = 400,
                LowerPriceLimit = 100,
            };

            var p8 = new Preferences
            {
                PreferencesID = 8,
                Gender = Gender.Male,
                Age = 30,
                UpperPriceLimit = 1000,
                LowerPriceLimit = 600,
            };

            var p9 = new Preferences
            {
                PreferencesID = 9,
                Gender = Gender.Female,
                Age = 20,
                UpperPriceLimit = 1500,
                LowerPriceLimit = 400,
            };

            var p10 = new Preferences
            {
                PreferencesID = 10,
                Gender = Gender.Male,
                Age = 20,
                UpperPriceLimit = 500,
                LowerPriceLimit = 0,
            };

            var prefs = new List<Preferences> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            context.Preferences.AddOrUpdate( x => x.PreferencesID, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

            var c1 = new Career
            {
                CareerID = 1,
                Company = "USA",
                JobTitle = "Former Prez"
            };

            var c2 = new Career
            {
                CareerID = 2,
                Company = "USA",
                JobTitle = "Prez"
            };

            var c3 = new Career
            {
                CareerID = 3,
                Company = "Rebels",
                JobTitle = "Smuggler"
            };

            var c4 = new Career
            {
                CareerID = 4,
                Company = "Cali",
                JobTitle = "Governor"
            };

            var c5 = new Career
            {
                CareerID = 5,
                Company = "Columbia Records",
                JobTitle = "Diva"
            };

            var c6 = new Career
            {
                CareerID = 6,
                Company = "Wayne Industries",
                JobTitle = "The Batman"
            };

            var c7 = new Career
            {
                CareerID = 7,
                Company = "7 seas",
                JobTitle = "Pirate"
            };

            var c8 = new Career
            {
                CareerID = 8,
                Company = "WBA",
                JobTitle = "Pigeon Enthusiast"
            };

            var c9 = new Career
            {
                CareerID = 9,
                Company = "Republic Records",
                JobTitle = "Donut Terrorist"
            };

            var c10 = new Career
            {
                CareerID = 10,
                Company = "7 Kingdoms",
                JobTitle = "Hand of the King"
            };

            var careers = new List<Career> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 };
            context.Careers.AddOrUpdate(x => x.CareerID, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);

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
                Preferences = p1,
                Job = c1,
                Tags = new List<Tag> { t1, t2, t3, t4, t29 },
            };

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
                Preferences = p2,
                Job = c2,
                Tags = new List<Tag> { t1, t5, t7, t31 }
            };

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
                Preferences = p3,
                Job = c3,
                Tags = new List<Tag> { t8, t9, t5, t27, t31 }
            };

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
                Preferences = p4,
                Job = c4,
                Tags = new List<Tag> { t1, t2, t5, t7, t11, t12, t13, t16, t23, t29 }
            };

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
                Preferences = p5,
                Job = c5,
                Tags = new List<Tag> { t9, t2 }
            };

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
                Preferences = p6,
                Job = c6,
                Tags = new List<Tag> { t12, t16, t17, t18, t19, t29, t31 }
            };

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
                Preferences = p7,
                Job = c7,
                Tags = new List<Tag> { t21, t22, t7, t5 }
            };

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
                Preferences = p8,
                Job = c8,
                Tags = new List<Tag> { t23, t24, t25, t17 }
            };

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
                Preferences = p9,
                Job = c9,
                Tags = new List<Tag> { t32, t14, t15, t10 }
            };

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
                Preferences = p10,
                Job = c10,
                Tags = new List<Tag> { t26, t29, t9, t30, t28, t7 }
            };

            context.Users.AddOrUpdate(x => x.Name, u1, u2, u3, u4, u5, u6, u7, u8, u9, u10);

            /*
            context.Careers.AddOrUpdate(x => x.Company,
                new Career()
                {
                    CareerID = 1,
                    Company = "Test Company 1",
                    JobTitle = "Test Title 1",
                    Users = null 
                },

                new Career() { 
                    CareerID = 2, 
                    Company = "Test Company 2", 
                    JobTitle = "Test Title 2",
                    Users = null 
                },

                new Career() 
                { 
                    CareerID = 3,
                    Company = "Test Compasny 3",
                    JobTitle = "Test Title 3",
                    Users = null 
                }
                );

            context.Locations.AddOrUpdate(x => x.LocationID,
                new Location() 
                {
                    LocationID = 1,
                    Latitude = 1, 
                    Longitude = 1
                },

                new Location()
                { 
                    LocationID = 2,
                    Latitude = 2,
                    Longitude = 2
                },

                new Location() 
                {
                    LocationID = 3, 
                    Latitude = 3, 
                    Longitude = 3
                }
                );

            context.Tags.AddOrUpdate(x => x.Name,
                new Tag() { TagID = 1, Name = "Test Tag 1", Users = null },
                new Tag() { TagID = 2, Name = "Test Tag 2", Users = null },
                new Tag() { TagID = 3, Name = "Test Tag 3", Users = null }
                );

            context.Housings.AddOrUpdate(x => x.Name,
                new Housing() 
                {
                    HousingID = 1,
                    Address = "Test Address 1", 
                    LocationID = 1,
                    Name = "Test Housing 1",
                    Residents = null
                },
                new Housing() 
                {
                    HousingID = 2,
                    Address = "Test Address 2",
                    LocationID = 2,
                    Name = "Test Housing 2",
                    Residents = null
                },
                new Housing() 
                {
                    HousingID = 3,
                    Address = "Test Address 3",
                    LocationID = 3,
                    Name = "Test Housing 3",
                    Residents = null
                }
                );

            context.Preferences.AddOrUpdate(x => x.PreferencesID,
                new Preferences()
                {
                    PreferencesID = 1,
                    Age = 1,
                    Gender = Gender.Male,
                    Locations = null,
                    LowerPriceLimit = 0,
                    UpperPriceLimit = 1,
                    Tags = null,
                    Housings = null
                },

                new Preferences()
                {
                    PreferencesID = 2,
                    Age = 2,
                    Gender = Gender.Female,
                    Locations = null,
                    LowerPriceLimit = 2,
                    UpperPriceLimit = 3,
                    Tags = null,
                    Housings = null
                },
                new Preferences()
                {
                    PreferencesID = 3,
                    Age = 3,
                    Gender = Gender.Male,
                    Locations = null,
                    LowerPriceLimit = 2,
                    UpperPriceLimit = 4,
                    Tags = null,
                    Housings = null
                },
                new Preferences()
                {
                    PreferencesID = 4,
                    Age = 4,
                    Gender = Gender.Male,
                    Locations = null,
                    LowerPriceLimit = 3,
                    UpperPriceLimit = 5,
                    Tags = null,
                    Housings = null
                }
                );

            context.Users.AddOrUpdate(x => x.Name,
                new User()
                {
                    UserID = 1,
                    Name = "Test User 1",
                    PhoneNumber = "111-111-1111",
                    Age = 1,
                    Gender = Gender.Male,
                    Email = "testEmail1@test.com",
                    Status = Status.HasVacancy,
                    FavoritedUserIDs = null,
                    Job = null,
                    Preferences = null,
                    Tags = null,
                    Housing = null,
                    HousingPrice = 500,
                    Bio = "Test Bio 1"
                },

                new User()
                {
                    UserID = 2,
                    Name = "Test User 2",
                    PhoneNumber = "222-222-2222",
                    Age = 1,
                    Gender = Gender.Female,
                    Email = "testEmail2@test.com",
                    Status = Status.NeedsHousingAndRoommate,
                    FavoritedUserIDs = null,
                    Job = null,
                    Preferences = null,
                    Tags = null,
                    Housing = null,
                    HousingPrice = 600,
                    Bio = "Test Bio 2"
                },

                new User()
                {
                    UserID = 3,
                    Name = "Test User 3",
                    PhoneNumber = "333-333-3333",
                    Age = 3,
                    Gender = Gender.Male,
                    Email = "testEmail3@test.com",
                    Status = Status.NeedsRoommateOnly,
                    FavoritedUserIDs = null,
                    Job = null,
                    Preferences = null,
                    Tags = null,
                    Housing = null,
                    HousingPrice = 700,
                    Bio = "Test Bio 3"
                }

                );
            */
        }
             
    }
}
