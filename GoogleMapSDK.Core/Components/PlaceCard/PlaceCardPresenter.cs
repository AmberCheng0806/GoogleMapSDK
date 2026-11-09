using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static GoogleMapSDK.Contract.Models.Place.PlaceDetail;

namespace GoogleMapSDK.Core.Components.PlaceCard
{
    internal class PlaceCardPresenter : IPlaceCardPresenter
    {
        private IPlaceDetailService PlaceDetailService;
        public PlaceCardPresenter(IPlaceDetailService placeDetailService)
        {
            PlaceDetailService = placeDetailService;
        }
        public async Task<Contract.Models.PlaceCard.PlaceCard> GetPlaceCard(string placeId)
        {
            var place = await PlaceDetailService.GetPlaceDetail(placeId);
            var photos = await PlaceDetailService.GetPhotos(placeId);
            return new Contract.Models.PlaceCard.PlaceCard(place.displayName.text, place.primaryTypeDisplayName?.text, Math.Round(place.rating, 1), place.regularOpeningHours?.openNow,
              place.regularOpeningHours?.weekdayDescriptions, GetNextOpenTime(place.regularOpeningHours?.weekdayDescriptions, place.regularOpeningHours?.openNow), GetNextCloseTime(place.regularOpeningHours?.weekdayDescriptions, place.regularOpeningHours?.openNow),
              place.nationalPhoneNumber, place.userRatingCount, GetPriceRange(place.priceRange?.startPrice?.units, place.priceRange?.endPrice?.units), photos.FirstOrDefault());
        }
        private string GetNextOpenTime(string[] weekdayDescriptions, bool? isOpenNow)
        {
            if (weekdayDescriptions == null || isOpenNow == true) return null;
            int weekNum = (int)DateTime.Now.DayOfWeek;
            while (true)
            {
                string detail = weekdayDescriptions[weekNum];
                if (detail.Contains("24 小時營業")) return detail.Split(':')[0] + "00:00";
                var match = Regex.Match(detail, @"^(?<day>星期.)\s*:\s*(?<open>\d{1,2}:\d{2})\s*[–-]\s*(?<close>\d{1,2}:\d{2})");
                if (match.Success)
                {
                    string day = match.Groups["day"].Value;
                    string open = match.Groups["open"].Value;
                    return day + " " + open;
                }
                weekNum += 1;
            }
        }
        private string GetNextCloseTime(string[] weekdayDescriptions, bool? isOpenNow)
        {
            if (weekdayDescriptions == null || isOpenNow == false) return null;
            int weekNum = (int)DateTime.Now.DayOfWeek;
            weekNum = weekNum - 1;
            string detail = weekdayDescriptions[weekNum];
            if (detail.Contains("24 小時營業")) return "24 小時營業";
            var match = Regex.Match(detail, @"^(?<day>星期.)\s*:\s*(?<open>\d{1,2}:\d{2})\s*[–-]\s*(?<close>\d{1,2}:\d{2})");
            if (match.Success)
            {
                string day = match.Groups["day"].Value;
                string close = match.Groups["close"].Value;
                return day + " " + close;
            }
            return null;
        }
        private string GetPriceRange(string startPrice, string endPrice)
        {
            if (startPrice == null || endPrice == null)
                return null;
            return $"{startPrice}-{endPrice}";
        }
    }
}
