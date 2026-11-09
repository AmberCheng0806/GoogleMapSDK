using GoogleMapSDK.Contract.Models.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Components
{
    public interface IGMapView
    {
        Task<LatLng> GetGMapDatas(string placeId);
    }
}
