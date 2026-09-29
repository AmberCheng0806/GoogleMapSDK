using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.Carousel
{
    public class CarouselPresenter : ICarousePresenter
    {
        private IGoogleMapAPIContext GoogleMapAPIContext;
        public CarouselPresenter(IGoogleMapAPIContext googleMapAPIContext) { GoogleMapAPIContext = googleMapAPIContext; }
        public async Task<List<string>> GetImages(string placeId)
        {
            var detail = await GoogleMapAPIContext.PlaceContext.GetDetailByPlaceIdAsyn(placeId);
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
