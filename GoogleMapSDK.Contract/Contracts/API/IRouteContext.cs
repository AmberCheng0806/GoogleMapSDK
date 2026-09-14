using GoogleMapSDK.Contract.Models.Route;
using HTTP_Utility;
using HTTP_Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IRouteContext
    {
        IHttpRequest HttpUtility { get; }
        Task<Routes> ComputeRoutesBylatLng(RouteRequestByLatLng routeRequestByLatLng);
        Task<Routes> ComputeRoutesByPlaceId(RouteRequestByPlaceIdOrAddress routeRequestByPlaceId);
        Task<Routes> ComputeRoutesByAddress(RouteRequestByPlaceIdOrAddress routeRequestByAddress);
    }
}
