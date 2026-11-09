using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Service;
using GoogleMapSDK.Contract.Models.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.GMap
{
    internal class GMapPresenter : IGMapPresenter
    {
        private IPlaceDetailService PlaceDetailService;
        public GMapPresenter(IPlaceDetailService placeDetailService)
        {
            PlaceDetailService = placeDetailService;
        }
        public async Task<LatLng> GetGMapDatas(string placeId)
        {
            var detail = await PlaceDetailService.GetPlaceDetail(placeId);
            return new LatLng(detail.location.latitude, detail.location.longitude);
        }
    }
}
