// See https://aka.ms/new-console-template for more information
using GoogleMapSDK.API;
using GoogleMapSDK.API.Route.Models;
using Microsoft.Extensions.Configuration;
using static GoogleMapSDK.API.Geocoding.Models.Geocoding;
IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
string apiKey = config["X-Goog-Api-Key"];
GoogleMapContext googleMapContext = new GoogleMapContext(apiKey);
//var result = await googleMapContext.GeocodingContext.GetlatLngByAddressAsync("台北101");
//Console.WriteLine(result.results[0].location.longitude);
//var result2 = await googleMapContext.GeocodingContext.GetAddressBylatLngAsync("25.0332276,121.5648681");
//Console.WriteLine(result2.results[0].formattedAddress);
//var result3 = await googleMapContext.GeocodingContext.GetByPlaceIdAsync("ChIJPSyKR2mpQjQRLB_JwBEp9H4");
//Console.WriteLine(result3.formattedAddress);
//var result1 = await googleMapContext.PlaceContext.GetDetailByPlaceIdAsyn("ChIJ41wbgbqrQjQR75mxQgbywys");
//Console.WriteLine(result1.formattedAddress);
//var result2 = await googleMapContext.PlaceContext.SearchTextAsync("Spicy Vegetarian Food in Sydney, Australia");
//Console.WriteLine(result2.places[0].formattedAddress);
//var result3 = await googleMapContext.PlaceContext.SearchNearByAsync(25.033964, 121.564468, new List<string>() { "restaurant" });
//Console.WriteLine(result3.places[0].formattedAddress);
//var result4 = await googleMapContext.PlaceContext.GetPhotosAsyn("places/ChIJ41wbgbqrQjQR75mxQgbywys/photos/AaVGc3nJRmhSdu76hbzyzlYRZEZmOQm6LgBTH7SQV1s0ced9WXFsUpoj3Un66DL4TVEyloYtTa6pUlxugCzw6qi8PLLlAwAIEEbrwlFyRQsyJxOwX13xI0q8JdO8IhBtChfF44Wb0pbqHQLIF2o2E0DR4fqjbyIPr2rmLZXxAs8YkooRIwe_fo3opBoJ-q8S4CnN7NSMU_47Z6YS0kodfVRqrBX8xIMvhhxeKpl653f7NWycYtIv_OJrM_gtkBSuw8QEyQSNr9leoAXlDNmkTUAvAZp5SMv0ljwHcudk1eLLvB9jK5SJ8WU-2fbiXJk9D58U-EFO8JR7h5ryH5QVTH7J37WOXWaT1WoQUVrC9NzcC8mEa6MQwMgjx-oekG3xUE_2jB0dEJxA_vU8eXaO-inOpxWWjas3g2nKU5pb0PuZ7oFjq2r_5m7wR6aG9-RNAA/media");
//Console.WriteLine(result4.photoUri);
//var result5 = await googleMapContext.PlaceContext.AutoCompleteAsync("台灣大學");
//Console.WriteLine(result5.suggestions[0].placePrediction.text.text);
//var result1 = await googleMapContext.RouteContext.ComputeRoutesBylatLng(new GoogleMapSDK.API.Route.Models.RouteRequestByLatLng(25.0478, 121.5170, 25.033964, 121.564468, new List<LatLng>() { new LatLng(25.0410, 121.5600), new LatLng(25.0420, 121.5700) }, "DRIVE", false, false, false));
//Console.WriteLine(result1.routes[0].distanceMeters);
//var result2 = await googleMapContext.RouteContext.ComputeRoutesByPlaceId(new RouteRequestByPlaceIdOrAddress("ChIJPSyKR2mpQjQRLB_JwBEp9H4", "ChIJLRGAeBCrQjQRF0kAOUxK9Fo", null, "DRIVE", false, false, false));
//Console.WriteLine(result2.routes[0].distanceMeters);
var result3 = await googleMapContext.RouteContext.ComputeRoutesByAddress(new RouteRequestByPlaceIdOrAddress("台北車站", "台北101", new List<string>() { "臺北市中山區民安里中山北路二段16巷咖啡瑪榭 中山店\"" }, "DRIVE", false, false, false));
//Console.WriteLine(result3.routes[0].legs[0].steps[0].distanceMeters);
//List<LatLng> location = result3.routes[0].legs[0].steps[0].polyline.encodedPolyline;
List<LatLng> location = result3.routes[0].polyline.points;
foreach (var item in location)
{
    Console.WriteLine(item.Lat);
    Console.WriteLine(item.Lng);
}
