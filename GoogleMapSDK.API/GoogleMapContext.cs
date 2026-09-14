using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.Place;
using GoogleMapSDK.API.Route;
using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Options;
using HTTP_Utility;
using HTTP_Utility.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapSDK.API
{
    public class GoogleMapContext : IGoogleMapAPIContext
    {
        public IGeocodingContext GeocodingContext { get; }
        public IPlaceContext PlaceContext { get; }
        public IRouteContext RouteContext { get; }
        private IHttpRequest HttpUtility;
        private IBaseInterceptor Interceptor;
        public GoogleMapContext(IGeocodingContext geocodingContext, IPlaceContext placeContext, IRouteContext routeContext, IBaseInterceptor interceptor, IHttpRequest httpUtility, IOptions<KeyOptions> options)
        {
            string key = options.Value.Key;
            interceptor.RequestHandler = request =>
            {
                request.Headers.Add("X-Goog-Api-Key", key);
            };
            httpUtility.SetInterceptor(interceptor);
            HttpUtility = httpUtility;
            Interceptor = interceptor;
            GeocodingContext = geocodingContext;
            PlaceContext = placeContext;
            RouteContext = routeContext;
        }
    }
}
