using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Place
{
    public class PlaceDetail
    {
        public string nationalPhoneNumber { get; set; }
        public string formattedAddress { get; set; }
        public Location location { get; set; }
        public float rating { get; set; }
        public Regularopeninghours regularOpeningHours { get; set; }
        public Displayname displayName { get; set; }
        public Review[] reviews { get; set; }
        public Photo[] photos { get; set; }

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

        public class Review
        {
            public string name { get; set; }
            public string relativePublishTimeDescription { get; set; }
            public int rating { get; set; }
            public Text text { get; set; }
            public Originaltext originalText { get; set; }
            public Authorattribution authorAttribution { get; set; }
            public string publishTime { get; set; }
            public string flagContentUri { get; set; }
            public string googleMapsUri { get; set; }
        }

        public class Text
        {
            public string text { get; set; }
            public string languageCode { get; set; }
        }

        public class Originaltext
        {
            public string text { get; set; }
            public string languageCode { get; set; }
        }

        public class Authorattribution
        {
            public string displayName { get; set; }
            public string uri { get; set; }
            public string photoUri { get; set; }
        }

        public class Photo
        {
            public string name { get; set; }
            public int widthPx { get; set; }
            public int heightPx { get; set; }
            public Authorattribution1[] authorAttributions { get; set; }
            public string flagContentUri { get; set; }
            public string googleMapsUri { get; set; }
        }

        public class Authorattribution1
        {
            public string displayName { get; set; }
            public string uri { get; set; }
            public string photoUri { get; set; }
        }


    }
}
