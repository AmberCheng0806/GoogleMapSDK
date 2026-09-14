using GoogleMapSDK.Contract.Contracts.API;
using HTTP_Utility;
using HTTP_Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.WebRequestMethods;
using Geo = GoogleMapSDK.Contract.Models.Geocoding;

namespace GoogleMapSDK.API.Geocoding
{
    public class GeocodingContext : IGeocodingContext
    {
        private IHttpRequest httpUtility;
        public IHttpRequest HttpUtility { get => httpUtility; }
        public GeocodingContext(IHttpRequest httpUtility) { httpUtility = httpUtility; }
        public async Task<Geo.Geocoding> GetlatLngByAddressAsync(string address)
        {
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/address/";
            return await HttpUtility.GetAsync<Geo.Geocoding>(address);
        }

        public async Task<Geo.Geocoding> GetAddressBylatLngAsync(string lat, string Lng)
        {
            string location = lat + "," + Lng;
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/location/";
            return await HttpUtility.GetAsync<Geo.Geocoding>(location);
        }

        public async Task<Geo.GeocodingByPlaceId> GetByPlaceIdAsync(string placeId)
        {
            HttpUtility.BaseUrl = "https://geocode.googleapis.com/v4/geocode/places/";
            return await HttpUtility.GetAsync<Geo.GeocodingByPlaceId>(placeId);
        }
    }
}
