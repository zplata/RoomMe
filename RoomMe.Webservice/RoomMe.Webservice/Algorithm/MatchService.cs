using RoomMe.Webservice.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace RoomMe.Webservice.Algorithm
{
    public class MatchService
    {
        RoomMeWebserviceContext db = new RoomMeWebserviceContext();

        // User A wants to live with user B
        public int GenerateMatchScoreOfPreferences(int userAID, int userBID)
        {
            User a = db.Users.Find(userAID);
            User b = db.Users.Find(userBID);

            if ((a == null) || (b == null) || (a.Status == Status.Inactive) || (b.Status == Status.Inactive))
            {
                return 0;
            }

            var score = 0;

            var matchingTags = GetMatchingTags(a.Tags, b.Preferences.Tags);

            score += 100 * matchingTags.Count;

            score += GenerateMatchScoreForAge(a.Preferences.Age.Value, b.Age);

            score += GenerateMatchScoreForGender(a.Preferences.Gender.Value, b.Gender);

            score += GenerateMatchScoreForPriceRange(a.Preferences.LowerPriceLimit.Value, a.Preferences.UpperPriceLimit.Value, b.Preferences.LowerPriceLimit.Value, b.Preferences.UpperPriceLimit.Value);

            var matchingHousing = GetMatchingHousings(a.Preferences.Housings, new List<Housing> { b.Housing });

            if (matchingHousing.Count > 0)
            {
                score += 1000;
            }

            var matchingLocation = GenerateHousingLocationScore(b.Housing, a.Preferences.Locations);

            return score;


        }

        // User A is trying to move in with user B
        public int GenerateMatchScoreOfMovingIn(int userAID, int userBID)
        {
            User a = db.Users.Find(userAID);
            User b = db.Users.Find(userBID);

            if ((a == null) || (b == null) || (a.Status == Status.Inactive) || (b.Status == Status.Inactive))
            {
                return 0;
            }

            var score = 0;

            var matchingTags = GetMatchingTags(a.Tags, b.Preferences.Tags);

            score += 100 * matchingTags.Count;

            score += GenerateMatchScoreForAge(a.Preferences.Age.Value, b.Age);

            score += GenerateMatchScoreForGender(a.Preferences.Gender.Value, b.Gender);

            score += GenerateMatchScoreForPrice(a.Preferences.LowerPriceLimit.Value, a.Preferences.UpperPriceLimit.Value, b.HousingPrice.Value);

            var matchingHousing = GetMatchingHousings(a.Preferences.Housings, new List<Housing>{b.Housing});

            if(matchingHousing.Count > 0)
            {
                score += 1000;
            }

            var matchingLocation = GenerateHousingLocationScore(b.Housing, a.Preferences.Locations);

            return score;
        }

        // User A is trying to fill a vacancy with user B
        public int GenerateMatchScoreOfFillingVacancy(int userAID, int userBID)
        {
            User a = db.Users.Find(userAID);
            User b = db.Users.Find(userBID);

            if ((a == null) || (b == null) || (a.Status == Status.Inactive) || (b.Status == Status.Inactive))
            {
                return 0;
            }

            var score = 0;

            var matchingTags = GetMatchingTags(a.Tags, b.Preferences.Tags);

            score += 100 * matchingTags.Count;

            score += GenerateMatchScoreForAge(a.Preferences.Age.Value, b.Age);

            score += GenerateMatchScoreForGender(a.Preferences.Gender.Value, b.Gender);

            return score;
        }

        public int GenerateMatchScoreForGender(Gender desired, Gender real)
        {
            if((desired == null) || (real == null))
            {
                return 0;
            }

            if(desired == real)
            {
                return 1000;
            }

            return 0;

        }

        public int GenerateMatchScoreForAge(int desired, int real)
        {

            if((desired == null) || (real == null))
            {
                return 0;
            }

            var score = 1000;

            return score - 200 * (Math.Abs(desired - real));
        }

        public int GenerateMatchScoreForPrice(double lowerEnd, double upperEnd, double givenPrice)
        {

            if((lowerEnd == null) || (upperEnd == null) || (givenPrice == null))
            {
                return 0;
            }

            double score = 1000;
            double range = upperEnd - lowerEnd;

            if(score > upperEnd)
            {
                var dif = score - upperEnd;
                var mult = dif / range;
                score -= 200 * dif / range;
            }
            else if(score < lowerEnd)
            {
                var dif = score - lowerEnd;
                var mult = dif / range;
                score -= 200 * dif / range;
            }

            return (int) score; 
        }

        // would user B accept user A's price range?
        public int GenerateMatchScoreForPriceRange(double lowerA, double upperA, double lowerB, double upperB)
        {
            var rangeA = upperA - lowerA;
            //check range coverage
            double coverage = 0;
            
            if((upperB >= upperA) && (lowerB <= lowerA))
            {
                coverage = 1; //100% of A's range is covered. Ideal match for A.
            } 
            else if((lowerB > upperA) || (upperB < lowerA)) // no overlap.
            {
                coverage = 0;
            }
            else
            {
                double upperLimitWithinA = upperB;
                double lowerLimitWithinA = lowerB;

                if(upperB > upperA)
                {
                    upperLimitWithinA = upperA;
                }
                if(lowerB < lowerA)
                {
                    lowerLimitWithinA = lowerA;
                }

                var rangeWithinA = upperLimitWithinA - lowerLimitWithinA;

                coverage = rangeWithinA / rangeA;
            }

            var coverageScore = 1000.00 * coverage;
            var rangeProximityScore = 500.00;

            if(coverage > 0)
            {
                var score = coverageScore + rangeProximityScore;
                return Convert.ToInt32(score);
            }

            else
            {
                double diff = 0;
                double mult = 0;

                if(lowerB > upperA) //A's range is below B
                {
                    diff = lowerB - upperA;
                }
                else if(lowerA > upperB) // A's range is above B
                {
                    diff = lowerA - upperB;
                }

                mult = diff / rangeA;

                // score based on how much above or below B's range is compared to A's range as a function of the size of A's range
                var score = rangeProximityScore * (1.0 - mult);
                
                return Convert.ToInt32(score);
            }

        }

        public List<Tag> GetMatchingTags(List<Tag> a, List<Tag> b)
        {
            if ((a == null) || (b == null))
            {
                return new List<Tag>();
            }

            var matchingTags = new List<Tag>();   

            foreach( var item in a )
            {
                foreach(var other in b)
                {
                    if(String.Equals(item.Name, other.Name))
                    {
                        matchingTags.Add(item);
                    }
                }
            }

            return matchingTags;
        }

        public List<Housing> GetMatchingHousings(List<Housing> a, List<Housing> b)
        {
            if ((a == null) || (b == null))
            {
                return new List<Housing>();
            }

            var matchingHousings = new List<Housing>();

            foreach (var item in a)
            {
                foreach (var other in b)
                {
                    if (String.Equals(item.Name, other.Name))
                    {
                        matchingHousings.Add(item);
                    }
                }
            }
            return matchingHousings;
        }

        public int GenerateMutuallyPreferredLocationsScore(List<Location> a, List<Location> b)
        {
            if ((a == null) || (b == null))
            {
                return 0;
            }

            double score = 0;
            int comparisons = 0;

            foreach( var loc in a )
            {
                foreach (var other in b)
                {
                    comparisons++;
                    var closenessScore = (100 / (CalculateDistance(loc, other)));
                    if(closenessScore < 0)
                    {
                        closenessScore = 0;
                    }
                    else if(closenessScore > 1000)
                    {
                        closenessScore = 1000;
                    }
                    score += closenessScore;
                }
            }

            return (int) score * (1 + (a.Count + b.Count) / 10);

        }

        public int GenerateHousingLocationScore(Housing housing, List<Location> locations)
        {
            if ((housing == null) || (locations == null))
            {
                return 0;
            }

            var score = GenerateMutuallyPreferredLocationsScore(new List<Location> { housing.Location }, locations);

            return score;
        }

        public double CalculateDistance(Location a, Location b)
        {
            var geoA = new GeoCoordinate(a.Latitude, a.Longitude);
            var geoB = new GeoCoordinate(b.Latitude, b.Longitude);

            var distInMeters = geoA.GetDistanceTo(geoB);
            var distInMiles = distInMeters * 0.000621371;

            return distInMiles + 0.001;
        }
    }
}