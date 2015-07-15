namespace RoomMe.Webservice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RoomMe.Webservice.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomMe.Webservice.Models.RoomMeWebserviceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomMe.Webservice.Models.RoomMeWebserviceContext context)
        {
            context.Careers.AddOrUpdate(x => x.CareerID,
                new Career() { CareerID = 1, Company = "Test Company 1", JobTitle = "Test Title 1", Users = null },
                new Career() { CareerID = 2, Company = "Test Company 2", JobTitle = "Test Title 2", Users = null },
                new Career() { CareerID = 3, Company = "Test Company 3", JobTitle = "Test Title 3", Users = null }
                );

            context.Locations.AddOrUpdate(x => x.LocationID,
                new Location() { LocationID = 1, Latitude = 1, Longitude = 1, Residents = null },
                new Location() { LocationID = 2, Latitude = 2, Longitude = 2, Residents = null },
                new Location() { LocationID = 3, Latitude = 3, Longitude = 3, Residents = null }
                );

            context.Tags.AddOrUpdate(x => x.TagID,
                new Tag() { TagID = 1, Name = "Test Tag 1", Users = null },
                new Tag() { TagID = 2, Name = "Test Tag 2", Users = null },
                new Tag() { TagID = 3, Name = "Test Tag 3", Users = null }
                );

            context.Preferences.AddOrUpdate(x => x.PreferencesID,
                new Preferences() { PreferencesID = 1, Age = 1, Gender = Gender.Male, Location = null, LowerPriceLimit = 0, UpperPriceLimit = 1, Tags = null},
                new Preferences() { PreferencesID = 2, Age = 2, Gender = Gender.Female, Location = null, LowerPriceLimit = 2, UpperPriceLimit = 3, Tags = null},
                new Preferences() { PreferencesID = 3, Age = 3, Gender = Gender.Male, Location = null, LowerPriceLimit = 2, UpperPriceLimit = 4, Tags = null}
                );

            context.Users.AddOrUpdate(x => x.UserID,
                new User() 
                { 
                    UserID = 1,
                    Name = "Test User 1", 
                    PhoneNumber = "111-111-1111", 
                    Age = 1, 
                    Gender = Gender.Male, 
                    CareerID = 1, 
                    Email = "testEmail1@test.com", 
                    Status = Status.HasVacancy, 
                    Favorites = null, 
                    IsActive = true, 
                    Job = null, 
                    PreferencesID = 1,
                    Tags = null, 
                    HousingLocation = null 
                },

                new User() 
                { 
                    UserID = 2,
                    Name = "Test User 2", 
                    PhoneNumber = "222-222-2222", 
                    Age = 2, 
                    Gender = Gender.Female, 
                    CareerID = 2, 
                    Email = "testEmail2@test.com", 
                    Status = Status.NeedsHousingAndRoommate, 
                    Favorites = null, 
                    IsActive = true, 
                    Job = null, 
                    PreferencesID = 2,
                    Tags = null, 
                    HousingLocation = null 
                },

                new User() 
                { 
                    UserID = 3,
                    Name = "Test User 3", 
                    PhoneNumber = "333-333-3333", 
                    Age = 3, 
                    Gender = Gender.Male, 
                    CareerID = 3, 
                    Email = "testEmail3@test.com", 
                    Status = Status.NeedsRoommateOnly, 
                    Favorites = null, 
                    IsActive = true, 
                    Job = null, 
                    PreferencesID = 3,
                    Tags = null, 
                    HousingLocation = null 
                }

                );
        }
    }
}
