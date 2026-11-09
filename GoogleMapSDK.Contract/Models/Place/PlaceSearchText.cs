using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Place
{
    public class PlaceSearchText
    {
        public Place[] places { get; set; }

        public class Place
        {
            public string id { get; set; }
            public string[] types { get; set; }
            public string nationalPhoneNumber { get; set; }
            public string formattedAddress { get; set; }
            public Location location { get; set; }
            public float rating { get; set; }
            public Regularopeninghours regularOpeningHours { get; set; }
            public Displayname displayName { get; set; }
        }

        public class Location
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Regularopeninghours
        {
            public bool openNow { get; set; }
            public Period[] periods { get; set; }
            public string[] weekdayDescriptions { get; set; }
            public DateTime nextCloseTime { get; set; }
        }

        public class Period
        {
            public Open open { get; set; }
            public Close close { get; set; }
        }

        public class Open
        {
            public int day { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
        }

        public class Close
        {
            public int day { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
        }

        public class Displayname
        {
            public string text { get; set; }
            public string languageCode { get; set; }
        }

    }
}
