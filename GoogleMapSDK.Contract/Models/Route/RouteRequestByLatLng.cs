using GoogleMapSDK.Contract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Route
{
    public class RouteRequestByLatLng
    {
        public double OriginLat { get; set; }
        public double OriginLng { get; set; }
        public double DestinationLat { get; set; }
        public double DestinationLng { get; set; }
        public List<LatLng> Intermediates { get; set; } = null;
        public TravelModeEnum travelMode { get; set; }
        public bool AvoidTolls { get; set; }
        public bool AvoidHighways { get; set; }
        public bool AvoidFerries { get; set; }

        public RouteRequestByLatLng(double originLat, double originLng, double destinationLat, double destinationLng, List<LatLng> intermediates = null, TravelModeEnum travelMode = TravelModeEnum.DRIVE, bool avoidTolls = false, bool avoidHighways = false, bool avoidFerries = false)
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
