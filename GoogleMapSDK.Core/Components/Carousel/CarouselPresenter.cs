using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.Carousel
{
    public class CarouselPresenter : ICarousePresenter
    {
        private IPlaceDetailService PlaceDetailService;
        public CarouselPresenter(IPlaceDetailService placeDetailService)
        {
            PlaceDetailService = placeDetailService;
        }
        public async Task<List<string>> GetImages(string placeId)
        {
            return await PlaceDetailService.GetPhotos(placeId);
        }
    }
}
