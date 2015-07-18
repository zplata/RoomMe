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
            context.Careers.AddOrUpdate(x => x.CareerID,
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

            var career1 = context.Careers.Find(1);
            var career2 = context.Careers.Find(2);
            var career3 = context.Careers.Find(3);

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

            var location1 = context.Locations.Find(1);
            var location2 = context.Locations.Find(2);
            var location3 = context.Locations.Find(3);

            context.Tags.AddOrUpdate(x => x.TagID,
                new Tag() { TagID = 1, Name = "Test Tag 1", Users = null },
                new Tag() { TagID = 2, Name = "Test Tag 2", Users = null },
                new Tag() { TagID = 3, Name = "Test Tag 3", Users = null }
                );

            var tag1 = context.Tags.Find(1);
            var tag2 = context.Tags.Find(2);
            var tag3 = context.Tags.Find(3);

            context.Housings.AddOrUpdate(x => x.HousingID,
                new Housing() 
                {
                    HousingID = 1,
                    Address = "Test Address 1", 
                    Location = location1,
                    Name = "Test Housing 1",
                    Residents = null
                },
                new Housing() 
                {
                    HousingID = 2,
                    Address = "Test Address 2", 
                    Location = location2,
                    Name = "Test Housing 2",
                    Residents = null
                },
                new Housing() 
                {
                    HousingID = 3,
                    Address = "Test Address 3", 
                    Location = location3,
                    Name = "Test Housing 3",
                    Residents = null
                }
                );

            var housing1 = context.Housings.Find(1);
            var housing2 = context.Housings.Find(2);
            var housing3 = context.Housings.Find(3);

            context.Preferences.AddOrUpdate(x => x.PreferencesID,
                new Preferences()
                {
                    PreferencesID = 1,
                    Age = 1,
                    Gender = Gender.Male,
                    Locations = new List<Location> { location1, location2, location3 },
                    LowerPriceLimit = 0,
                    UpperPriceLimit = 1,
                    Tags = new List<Tag> 
                    {
                        tag1, tag2, tag3
                    },
                    Housings = new List<Housing> { housing1, housing2, housing3 }
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

            var pref1 = context.Preferences.Find(1);
            var pref2 = context.Preferences.Find(2);
            var pref3 = context.Preferences.Find(3);

            context.Users.AddOrUpdate(x => x.UserID,
                new User()
                {
                    UserID = 1,
                    Name = "Test User 1",
                    PhoneNumber = "111-111-1111",
                    Age = 1,
                    Gender = Gender.Male,
                    Email = "testEmail1@test.com",
                    Status = Status.HasVacancy,
                    Favorites = null,
                    Job = career1,
                    PreferencesID = 1,
                    Tags = new List<Tag> {tag1, tag2, tag3 },
                    Housing = housing1,
                    HousingPrice = 500
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
                    Favorites = null,
                    Job = null,
                    PreferencesID = 2,
                    Tags = null,
                    Housing = null,
                    HousingPrice = 600
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
                    Favorites = null,
                    Job = null,
                    PreferencesID = 2,
                    Tags = null,
                    Housing = null,
                    HousingPrice = 700
                }

                );

            var user1 = context.Users.Find(1);
            var user2 = context.Users.Find(2);
            var user3 = context.Users.Find(3);

            context.Users.AddOrUpdate(x => x.UserID,
                new User()
                {
                    UserID = 4,
                    Name = "Test User 4",
                    PhoneNumber = "444-444-4444",
                    Age = 4,
                    Gender = Gender.Female,
                    Email = "testEmail4@test.com",
                    Status = Status.Inactive,
                    Favorites = new List<User> { user1, user2, user3 },
                    Job = career1,
                    PreferencesID = 4,
                    Tags = new List<Tag> { tag1, tag2, tag3 },
                    Housing = housing1,
                    HousingPrice = 800
                });
        }
    }
}
