using GoogleMapSDK.Contract.Models.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Presenter
{
    public interface IGMapPresenter
    {
        Task<LatLng> GetGMapDatas(string placeId);
    }
}
