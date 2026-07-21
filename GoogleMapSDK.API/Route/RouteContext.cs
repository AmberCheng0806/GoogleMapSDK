using GoogleMapSDK.API.Util;
using HTTP_Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapSDK.API.Route
{
    public class RouteContext
    {
        private HTTP_Utility.HttpUtility HttpUtility;
        private JsonSerializerSettings settings = new JsonSerializerSettings();
        public RouteContext(HTTP_Utility.HttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
            HttpUtility.BaseUrl = "https://routes.googleapis.com/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "routes.distanceMeters,routes.duration,routes.legs.steps.distanceMeters,routes.legs.steps.staticDuration,routes.legs.steps.navigationInstruction,routes.legs.steps.transitDetails,routes.routeLabels,routes.legs.steps.polyline.encodedPolyline,routes.polyline.encodedPolyline");
            settings.Converters.Add(new GooglePolylineConverter());
        }
        public async Task<Route.Models.Routes> ComputeRoutesBylatLng(Route.Models.RouteRequestByLatLng routeRequestByLatLng)
        {
            var intermediates = routeRequestByLatLng.Intermediates == null ?
                new object[] { } : routeRequestByLatLng.Intermediates.Select(x => new
                {
                    location = new
                    {
                        latLng = new
                        {
                            latitude = x.Lat,
                            longitude = x.Lng
                        }
                    }
                }).ToArray();

            return await HttpUtility.PostAsync<Route.Models.Routes>("directions/v2:computeRoutes", new
            {
                origin = new
                {
                    location = new
                    {
                        latLng = new
                        {
                            latitude = routeRequestByLatLng.OriginLat,
                            longitude = routeRequestByLatLng.OriginLng
                        }
                    }
                },
                destination = new
                {
                    location = new
                    {
                        latLng = new
                        {
                            latitude = routeRequestByLatLng.DestinationLat,
                            longitude = routeRequestByLatLng.DestinationLng
                        }
                    }
                },
                intermediates = intermediates,
                travelMode = routeRequestByLatLng.travelMode,
                computeAlternativeRoutes = true,
                routeModifiers = new
                {
                    avoidTolls = routeRequestByLatLng.AvoidTolls,
                    avoidHighways = routeRequestByLatLng.AvoidHighways,
                    avoidFerries = routeRequestByLatLng.AvoidFerries
                },
                languageCode = "zh-TW",
                units = "METRIC"
            }, jsonSerializerSettings: settings
            );
        }

        public async Task<Route.Models.Routes> ComputeRoutesByPlaceId(Route.Models.RouteRequestByPlaceIdOrAddress routeRequestByPlaceId)
        {
            var intermediates = routeRequestByPlaceId.Intermediates == null ?
                new object[] { } : routeRequestByPlaceId.Intermediates.Select(x => new
                {
                    placeId = x
                }).ToArray();

            return await HttpUtility.PostAsync<Route.Models.Routes>("directions/v2:computeRoutes", new
            {
                origin = new
                {
                    placeId = routeRequestByPlaceId.Origin
                },
                destination = new
                {
                    placeId = routeRequestByPlaceId.Destination
                },
                intermediates = intermediates,
                travelMode = routeRequestByPlaceId.travelMode,
                computeAlternativeRoutes = true,
                routeModifiers = new
                {
                    avoidTolls = routeRequestByPlaceId.AvoidTolls,
                    avoidHighways = routeRequestByPlaceId.AvoidHighways,
                    avoidFerries = routeRequestByPlaceId.AvoidFerries
                },
                languageCode = "zh-TW",
                units = "METRIC"
            }, jsonSerializerSettings: settings
            );
        }

        public async Task<Route.Models.Routes> ComputeRoutesByAddress(Route.Models.RouteRequestByPlaceIdOrAddress routeRequestByAddress)
        {
            var intermediates = routeRequestByAddress.Intermediates == null ?
                new object[] { } : routeRequestByAddress.Intermediates.Select(x => new
                {
                    address = x
                }).ToArray();

            return await HttpUtility.PostAsync<Route.Models.Routes>("directions/v2:computeRoutes", new
            {
                origin = new
                {
                    address = routeRequestByAddress.Origin
                },
                destination = new
                {
                    address = routeRequestByAddress.Destination
                },
                intermediates = intermediates,
                travelMode = routeRequestByAddress.travelMode,
                computeAlternativeRoutes = true,
                routeModifiers = new
                {
                    avoidTolls = routeRequestByAddress.AvoidTolls,
                    avoidHighways = routeRequestByAddress.AvoidHighways,
                    avoidFerries = routeRequestByAddress.AvoidFerries
                },
                languageCode = "zh-TW",
                units = "METRIC"
            }, jsonSerializerSettings: settings
            );
        }
    }
}
