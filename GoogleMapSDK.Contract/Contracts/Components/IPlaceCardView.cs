using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Components
{
    public interface IPlaceCardView
    {
        string Name { get; set; }
        string Type { get; set; }
        double Rating { get; set; }
        int UserRatingCount { get; set; }
        string PriceRange { get; set; }
        bool? OpenNow { get; set; }
        string[] WeekdayDescriptions { get; set; }
        string NextOpenTime { get; set; }
        string NextCloseTime { get; set; }
        string PhoneNumber { get; set; }
        string OpeningStatus { get; }
        Task GetPlaceCard(string placeId);
    }
}
