using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Service;
using GoogleMapSDK.Contract.Models.Place;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.Util
{
    public class PlaceDetailService : IPlaceDetailService
    {
        private IGoogleMapAPIContext GoogleMapAPIContext;
        private Dictionary<string, PlaceDetail> Cache = new Dictionary<string, PlaceDetail>();
        private Dictionary<string, List<string>> photos = new Dictionary<string, List<string>>();
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
        public async Task<List<string>> GetPhotos(string placeId)
        {
            if (photos.ContainsKey(placeId)) return photos[placeId];
            var detail = await GetPlaceDetail(placeId);
            List<string> names = detail.photos?.Select(p => p.name).ToList() ?? new List<string>();
            var uris = names.Select(async x =>
            {
                var photo = await GoogleMapAPIContext.PlaceContext.GetPhotosAsyn(x);
                return photo.photoUri;
            }).ToList();
            var result = await Task.WhenAll(uris);
            return result.ToList();
        }
    }
}
