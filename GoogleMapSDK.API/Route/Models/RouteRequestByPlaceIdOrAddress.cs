using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Route.Models
{
    public class RouteRequestByPlaceIdOrAddress
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public List<string> Intermediates { get; set; }
        public string travelMode { get; set; }
        public bool AvoidTolls { get; set; }
        public bool AvoidHighways { get; set; }
        public bool AvoidFerries { get; set; }

        public RouteRequestByPlaceIdOrAddress(string origin, string destination, List<string> intermediates, string travelMode, bool avoidTolls, bool avoidHighways, bool avoidFerries)
        {
            Origin = origin;
            Destination = destination;
            Intermediates = intermediates;
            this.travelMode = travelMode;
            AvoidTolls = avoidTolls;
            AvoidHighways = avoidHighways;
            AvoidFerries = avoidFerries;
        }
    }
}
