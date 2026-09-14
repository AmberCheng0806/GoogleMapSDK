using GoogleMapSDK.API.Util;
using GoogleMapSDK.Contract.Models.Route;
using HTTP_Utility;
using Newtonsoft.Json;
using GoogleMapSDK.Contract.Contracts.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HTTP_Utility.Interfaces;

namespace GoogleMapSDK.API.Route
{
    public class RouteContext : IRouteContext
    {
        private IHttpRequest httpUtility;
        public IHttpRequest HttpUtility { get => httpUtility; }
        private JsonSerializerSettings settings = new JsonSerializerSettings();
        public RouteContext(IHttpRequest httpUtility)
        {
            httpUtility = httpUtility;
            settings.Converters.Add(new GooglePolylineConverter());
        }
        private void SharedSetting()
        {
            HttpUtility.BaseUrl = "https://routes.googleapis.com/";
            HttpUtility.AddHeaders("X-Goog-FieldMask", "routes.distanceMeters,routes.duration,routes.legs.steps.distanceMeters,routes.legs.steps.staticDuration,routes.legs.steps.navigationInstruction,routes.legs.steps.transitDetails,routes.routeLabels,routes.legs.steps.polyline.encodedPolyline,routes.polyline.encodedPolyline");
        }
        public async Task<Routes> ComputeRoutesBylatLng(RouteRequestByLatLng routeRequestByLatLng)
        {
            SharedSetting();
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

            return await HttpUtility.PostAsync<Routes>("directions/v2:computeRoutes", new
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

        public async Task<Routes> ComputeRoutesByPlaceId(RouteRequestByPlaceIdOrAddress routeRequestByPlaceId)
        {
            SharedSetting();
            var intermediates = routeRequestByPlaceId.Intermediates == null ?
                new object[] { } : routeRequestByPlaceId.Intermediates.Select(x => new
                {
                    placeId = x
                }).ToArray();

            return await HttpUtility.PostAsync<Routes>("directions/v2:computeRoutes", new
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

        public async Task<Routes> ComputeRoutesByAddress(RouteRequestByPlaceIdOrAddress routeRequestByAddress)
        {
            SharedSetting();
            var intermediates = routeRequestByAddress.Intermediates == null ?
                new object[] { } : routeRequestByAddress.Intermediates.Select(x => new
                {
                    address = x
                }).ToArray();

            return await HttpUtility.PostAsync<Routes>("directions/v2:computeRoutes", new
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
