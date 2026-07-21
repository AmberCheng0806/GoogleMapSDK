using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapSDK.API.Route.Models.Routes;

namespace GoogleMapSDK.API.Route.Models
{
    public class RouteRequestByLatLng
    {
        public double OriginLat { get; set; }
        public double OriginLng { get; set; }
        public double DestinationLat { get; set; }
        public double DestinationLng { get; set; }
        public List<LatLng> Intermediates { get; set; }
        public string travelMode { get; set; }
        public bool AvoidTolls { get; set; }
        public bool AvoidHighways { get; set; }
        public bool AvoidFerries { get; set; }

        public RouteRequestByLatLng(double originLat, double originLng, double destinationLat, double destinationLng, List<LatLng> intermediates, string travelMode, bool avoidTolls, bool avoidHighways, bool avoidFerries)
        {
            OriginLat = originLat;
            OriginLng = originLng;
            DestinationLat = destinationLat;
            DestinationLng = destinationLng;
            Intermediates = intermediates;
            this.travelMode = travelMode;
            AvoidTolls = avoidTolls;
            AvoidHighways = avoidHighways;
            AvoidFerries = avoidFerries;
        }
    }
}
