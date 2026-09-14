using GoogleMapSDK.Contract.Models.Route;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API.Util
{
    public class GooglePolylineConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.Path.EndsWith("encodedPolyline"))
            {
                string polylineString = reader.Value.ToString();
                if (string.IsNullOrWhiteSpace(polylineString))
                {
                    return new List<LatLng>();
                }
                return GooglePolyline.Decode(polylineString).ToList();
            }
            return new List<LatLng>();
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(List<LatLng>)) return true;
            return false;
        }
    }
}
