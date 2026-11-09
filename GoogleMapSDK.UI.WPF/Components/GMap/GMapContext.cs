using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.GMap
{
    public class GMapContext : IGMapView
    {
        private IGMapPresenter GMapPresenter;
        public GMapContext(IGMapPresenter gMapPresenter)
        {
            GMapPresenter = gMapPresenter;
        }
        public async Task<Contract.Models.Route.LatLng> GetGMapDatas(string placeId)
        {
            return await GMapPresenter.GetGMapDatas(placeId);
        }
    }
}
