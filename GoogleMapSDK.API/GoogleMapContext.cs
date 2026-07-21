using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.Place;
using GoogleMapSDK.API.Route;
using HTTP_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapSDK.API
{
    public class GoogleMapContext
    {
        public GeocodingContext GeocodingContext { get; set; }
        public PlaceContext PlaceContext { get; set; }
        public RouteContext RouteContext { get; set; }
        private HTTP_Utility.HttpUtility HttpUtility { get; set; }
        private Interceptor interceptor = new Interceptor();

        public GoogleMapContext(string key)
        {
            interceptor.RequestHandler = request =>
            {
                request.Headers.Add("X-Goog-Api-Key", key);
            };
            HttpUtility = new HTTP_Utility.HttpUtility(false, interceptor);
            GeocodingContext = new GeocodingContext(HttpUtility);
            PlaceContext = new PlaceContext(HttpUtility);
            RouteContext = new RouteContext(HttpUtility);
        }
    }
}
