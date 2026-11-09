using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Place
{
    public class PlaceIdByText
    {
        public Place[] places { get; set; }

        public class Place
        {
            public string id { get; set; }
            public Location location { get; set; }
        }

        public class Location
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }
    }
}
