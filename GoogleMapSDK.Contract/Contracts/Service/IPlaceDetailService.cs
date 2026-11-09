using GoogleMapSDK.Contract.Models.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Service
{
    public interface IPlaceDetailService
    {
        Task<PlaceDetail> GetPlaceDetail(string placeId);
        Task<List<string>> GetPhotos(string placeId);
    }
}
