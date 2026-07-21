using GoogleMapSDK.API.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Route.Models
{
    public class Routes
    {
        public Route[] routes { get; set; }

        public class Route
        {
            public Leg[] legs { get; set; }
            public int distanceMeters { get; set; }
            public string duration { get; set; }
            public Polyline polyline { get; set; }
            public string[] routeLabels { get; set; }
        }

        public class Polyline
        {
            ////public string encodedPolyline { get; set; }
            [JsonProperty("encodedPolyline")]
            //[JsonConverter(typeof(GooglePolylineConverter))]
            public List<LatLng> points { get; set; }
        }

        public class Leg
        {
            public Step[] steps { get; set; }
        }

        public class Step
        {
            public int distanceMeters { get; set; }
            public string staticDuration { get; set; }
            public Polyline1 polyline { get; set; }
            public Navigationinstruction navigationInstruction { get; set; }
            public Transitdetails transitDetails { get; set; }
        }

        public class Polyline1
        {
            //public string encodedPolyline { get; set; }
            [JsonProperty("encodedPolyline")]
            //[JsonConverter(typeof(GooglePolylineConverter))]
            public List<LatLng> points { get; set; }
        }

        public class Navigationinstruction
        {
            public string instructions { get; set; }
            public string maneuver { get; set; }
        }

        public class Transitdetails
        {
            public Stopdetails stopDetails { get; set; }
            public Localizedvalues localizedValues { get; set; }
            public string headsign { get; set; }
            public Transitline transitLine { get; set; }
            public int stopCount { get; set; }
        }

        public class Stopdetails
        {
            public Arrivalstop arrivalStop { get; set; }
            public DateTime arrivalTime { get; set; }
            public Departurestop departureStop { get; set; }
            public DateTime departureTime { get; set; }
        }

        public class Arrivalstop
        {
            public string name { get; set; }
            public Location location { get; set; }
        }

        public class Location
        {
            public Latlng latLng { get; set; }
        }

        public class Latlng
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Departurestop
        {
            public string name { get; set; }
            public Location1 location { get; set; }
        }

        public class Location1
        {
            public Latlng1 latLng { get; set; }
        }

        public class Latlng1
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Localizedvalues
        {
            public Arrivaltime arrivalTime { get; set; }
            public Departuretime departureTime { get; set; }
        }

        public class Arrivaltime
        {
            public Time time { get; set; }
            public string timeZone { get; set; }
        }

        public class Time
        {
        }

        public class Departuretime
        {
            public Time1 time { get; set; }
            public string timeZone { get; set; }
        }

        public class Time1
        {
        }

        public class Transitline
        {
            public Agency[] agencies { get; set; }
            public string name { get; set; }
            public string color { get; set; }
            public string iconUri { get; set; }
            public string nameShort { get; set; }
            public string textColor { get; set; }
            public Vehicle vehicle { get; set; }
        }

        public class Vehicle
        {
            public Name name { get; set; }
            public string type { get; set; }
            public string iconUri { get; set; }
            public string localIconUri { get; set; }
        }

        public class Name
        {
            public string text { get; set; }
        }

        public class Agency
        {
            public string name { get; set; }
            public string phoneNumber { get; set; }
            public string uri { get; set; }
        }


    }
}
