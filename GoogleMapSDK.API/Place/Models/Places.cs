using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Place.Models
{
    public class Places
    {
        public Place[] places { get; set; }

        public class Place
        {
            public string id { get; set; }
            public string formattedAddress { get; set; }
            public string priceLevel { get; set; }
            public Displayname displayName { get; set; }
        }

        public class Displayname
        {
            public string text { get; set; }
            public string languageCode { get; set; }
        }

    }
}
