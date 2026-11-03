using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Service;
using GoogleMapSDK.Contract.Models.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.Util
{
    public class PlaceDetailService : IPlaceDetailService
    {
        private IGoogleMapAPIContext GoogleMapAPIContext;
        private Dictionary<string, PlaceDetail> Cache = new Dictionary<string, PlaceDetail>();
        public PlaceDetailService(IGoogleMapAPIContext googleMapAPIContext)
        {
            GoogleMapAPIContext = googleMapAPIContext;
        }
        public async Task<PlaceDetail> GetPlaceDetail(string placeId)
        {
            if (Cache.ContainsKey(placeId)) return Cache[placeId];
            var detail = await GoogleMapAPIContext.PlaceContext.GetDetailByPlaceIdAsyn(placeId);
            Cache.Add(placeId, detail);
            return detail;
        }
    }
}
