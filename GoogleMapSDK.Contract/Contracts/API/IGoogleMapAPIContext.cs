using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IGoogleMapAPIContext
    {
        IGeocodingContext GeocodingContext { get; }
        IPlaceContext PlaceContext { get; }
        IRouteContext RouteContext { get; }
    }
}
