using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.PlaceCard
{
    public class PlaceCard
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
        public int UserRatingCount { get; set; }
        public string PriceRange { get; set; }
        public bool? OpenNow { get; set; }
        public string[] WeekdayDescriptions { get; set; }
        public string NextOpenTime { get; set; }
        public string NextCloseTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }

        public PlaceCard(string name, string type, double rating, bool? openNow, string[] weekdayDescriptions, string nextOpenTime, string nextCloseTime, string phoneNumber, int userRatingCount, string priceRange, string photo)
        {
            Name = name;
            Type = type;
            Rating = rating;
            OpenNow = openNow;
            WeekdayDescriptions = weekdayDescriptions;
            NextOpenTime = nextOpenTime;
            NextCloseTime = nextCloseTime;
            PhoneNumber = phoneNumber;
            UserRatingCount = userRatingCount;
            PriceRange = priceRange;
            Photo = photo;
        }
    }
}
