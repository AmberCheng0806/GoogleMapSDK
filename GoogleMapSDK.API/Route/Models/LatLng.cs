using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Route.Models
{
    public class LatLng
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}
