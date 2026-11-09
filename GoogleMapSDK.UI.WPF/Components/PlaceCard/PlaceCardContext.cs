using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.PlaceCard
{
    [AddINotifyPropertyChangedInterface]
    public class PlaceCardContext : IPlaceCardView
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
        public string OpeningStatus => OpenNow == true ? "營業中" : OpenNow == null ? null : "已打烊";
        private IPlaceCardPresenter PlaceCardPresenter;
        public PlaceCardContext(IPlaceCardPresenter placeCardPresenter)
        {
            PlaceCardPresenter = placeCardPresenter;
        }

        public async Task GetPlaceCard(string placeId)
        {
            var place = await PlaceCardPresenter.GetPlaceCard(placeId);
            Name = place.Name;
            Type = place.Type;
            UserRatingCount = place.UserRatingCount;
            Rating = place.Rating;
            PriceRange = place.PriceRange;
            OpenNow = place.OpenNow;
            WeekdayDescriptions = place.WeekdayDescriptions;
            NextOpenTime = place.NextOpenTime;
            NextCloseTime = place.NextCloseTime;
            PhoneNumber = place.PhoneNumber;
            Photo = place.Photo;
        }

    }
}
