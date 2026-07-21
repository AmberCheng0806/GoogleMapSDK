using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Place
{
    public class PlaceContext
    {
        private HttpUtility HttpUtility;
        public PlaceContext(HttpUtility httpUtility) { HttpUtility = httpUtility; }
        public async Task<Place.Models.PlaceDetail> GetDetailByPlaceIdAsyn(string placeId)
        {
            HttpUtility.BaseUrl = "https://places.googleapis.com/v1/places/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "displayName,formattedAddress,location,rating,nationalPhoneNumber,regularOpeningHours,photos");
            return await HttpUtility.GetAsync<Place.Models.PlaceDetail>(placeId);
        }
        public async Task<Place.Models.Places> SearchTextAsync(string text)
        {
            HttpUtility.BaseUrl = "https://places.googleapis.com/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "places.id,places.displayName,places.formattedAddress,places.priceLevel");
            return await HttpUtility.PostAsync<Place.Models.Places>("v1/places:searchText", new
            {
                textQuery = text,
                languageCode = "zh-TW"
            }
            );
        }
        public async Task<Place.Models.Places> SearchNearByAsync(double lat, double Lng, List<string> types, string radium = "500")
        {
            HttpUtility.BaseUrl = "https://places.googleapis.com/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "places.id,places.displayName,places.formattedAddress,places.priceLevel");
            return await HttpUtility.PostAsync<Place.Models.Places>("v1/places:searchNearby", new
            {
                includedTypes = types.ToArray(),
                maxResultCount = 20,
                languageCode = "zh-TW",
                locationRestriction = new
                {
                    circle = new
                    {
                        center = new
                        {
                            latitude = lat,
                            longitude = Lng
                        },
                        radius = radium
                    }
                }
            }
            );
        }
        public async Task<Place.Models.PlacePhoto> GetPhotosAsyn(string placeName, string height = "400", string width = "600")
        {
            HttpUtility.BaseUrl = "https://places.googleapis.com/v1/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "");
            return await HttpUtility.GetAsync<Place.Models.PlacePhoto>(placeName, new Dictionary<string, string>()
                {
                    {"maxHeightPx",height },
                    {"maxWidthPx",width},
                    {"skipHttpRedirect","true" }
                });
        }
        public async Task<Place.Models.PlaceAutoComplete> AutoCompleteAsync(string text)
        {
            HttpUtility.BaseUrl = "https://places.googleapis.com/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "");
            return await HttpUtility.PostAsync<Place.Models.PlaceAutoComplete>("v1/places:autocomplete", new
            {
                input = text,
                languageCode = "zh-TW"
            }
            );
        }
    }
}
