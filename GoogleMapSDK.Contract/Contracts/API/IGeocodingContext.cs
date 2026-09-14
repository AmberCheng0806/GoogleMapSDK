using HTTP_Utility;
using HTTP_Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geo = GoogleMapSDK.Contract.Models.Geocoding;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IGeocodingContext
    {
        IHttpRequest HttpUtility { get; }
        Task<Geo.Geocoding> GetlatLngByAddressAsync(string address);
        Task<Geo.Geocoding> GetAddressBylatLngAsync(string lat, string Lng);
        Task<Geo.GeocodingByPlaceId> GetByPlaceIdAsync(string placeId);
    }
}
