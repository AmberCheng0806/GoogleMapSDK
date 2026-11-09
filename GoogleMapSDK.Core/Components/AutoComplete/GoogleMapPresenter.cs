using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Models.Route;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete
{
    public class GoogleMapPresenter : IAutoCompletePresenter<Place>
    {
        private IGoogleMapAPIContext GoogleMapContext;

        public GoogleMapPresenter(IGoogleMapAPIContext googleMapAPIContext)
        {
            GoogleMapContext = googleMapAPIContext;
        }
        public async Task<IEnumerable<Place>> GetSearchResults(string inputText)
        {
            var autoComplete = await GoogleMapContext.PlaceContext.AutoCompleteAsync(inputText);
            if (autoComplete.suggestions == null) return null;
            var list = autoComplete.suggestions.Select(async x =>
            {
                var searchText = await GoogleMapContext.PlaceContext.GetPlaceIdByTextAsync(x.placePrediction.text.text);
                var place = searchText.places[0];
                return new Place
                {
                    Name = x.placePrediction.text.text,
                    Value = place.id,
                    Location = new LatLng(searchText.places[0].location.latitude, searchText.places[0].location.longitude)
                };
            }).ToList();
            var result = await Task.WhenAll(list);
            return result;
        }

        private string GetNextOpenTime(string[] weekdayDescriptions)
        {
            if (weekdayDescriptions == null) return null;
            int weekNum = (int)DateTime.Now.DayOfWeek;
            string detail = weekdayDescriptions[weekNum];
            var match = Regex.Match(detail, @"\d{1,2}:\d{2}");
            return match.Value;
        }
    }
}
