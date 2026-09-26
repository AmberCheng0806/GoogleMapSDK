using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
                var searchText = await GoogleMapContext.PlaceContext.SearchTextAsync(x.placePrediction.text.text);
                return new Place
                {
                    Name = searchText.places[0].displayName.text,
                    Value = searchText.places[0].id
                };
            }).ToList();
            var result = await Task.WhenAll(list);
            return result;
        }
    }
}
