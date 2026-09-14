using GoogleMapSDK.Contract.Models.Place;
using HTTP_Utility;
using HTTP_Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IPlaceContext
    {
        IHttpRequest HttpUtility { get; }
        Task<PlaceDetail> GetDetailByPlaceIdAsyn(string placeId);
        Task<Places> SearchTextAsync(string text);
        Task<Places> SearchNearByAsync(double lat, double Lng, List<string> types, string radium = "500");
        Task<PlacePhoto> GetPhotosAsyn(string placeName, string height = "400", string width = "600");
        Task<PlaceAutoComplete> AutoCompleteAsync(string text);

    }
}
