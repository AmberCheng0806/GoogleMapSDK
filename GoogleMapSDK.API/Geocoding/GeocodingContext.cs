using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;

namespace GoogleMapSDK.API.Geocoding
{
    public class GeocodingContext
    {
        private HTTP_Utility.HttpUtility HttpUtility;
        public GeocodingContext(HTTP_Utility.HttpUtility httpUtility) { HttpUtility = httpUtility; }
        public async Task<Geocoding.Models.Geocoding> GetlatLngByAddressAsync(string address)
        {
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/address/";
            return await HttpUtility.GetAsync<Geocoding.Models.Geocoding>(address);
        }

        public async Task<Geocoding.Models.Geocoding> GetAddressBylatLngAsync(string lat, string Lng)
        {
            string location = lat + "," + Lng;
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/location/";
            return await HttpUtility.GetAsync<Geocoding.Models.Geocoding>(location);
        }

        public async Task<Geocoding.Models.GeocodingByPlaceId> GetByPlaceIdAsync(string placeId)
        {
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/places/";
            return await HttpUtility.GetAsync<Geocoding.Models.GeocodingByPlaceId>(placeId);
        }
    }
}
