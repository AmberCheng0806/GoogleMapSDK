using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Geocoding
{
    public class Geocoding
    {
        public Result[] results { get; set; }


        public class Result
        {
            public string place { get; set; }
            public string placeId { get; set; }
            public Location location { get; set; }
            public string granularity { get; set; }
            public Viewport viewport { get; set; }
            public string formattedAddress { get; set; }
            public Postaladdress postalAddress { get; set; }
            public Addresscomponent[] addressComponents { get; set; }
            public string[] types { get; set; }
            public Pluscode plusCode { get; set; }
        }

        public class Location
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Viewport
        {
            public Low low { get; set; }
            public High high { get; set; }
        }

        public class Low
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class High
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Postaladdress
        {
            public string regionCode { get; set; }
            public string languageCode { get; set; }
            public string postalCode { get; set; }
            public string administrativeArea { get; set; }
            public string locality { get; set; }
            public string[] addressLines { get; set; }
        }

        public class Pluscode
        {
            public string globalCode { get; set; }
            public string compoundCode { get; set; }
        }

        public class Addresscomponent
        {
            public string longText { get; set; }
            public string shortText { get; set; }
            public string[] types { get; set; }
            public string languageCode { get; set; }
        }

    }
}
