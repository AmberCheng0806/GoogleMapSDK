using GoogleMapSDK.API.Geocoding;
using GoogleMapSDK.API.Place;
using GoogleMapSDK.API.Route;
using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Options;
using HTTP_Utility;
using HTTP_Utility.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.API
{
    public static class GoogleMapAPIRegistration
    {
        public static IServiceCollection AddGoogleMapAPIService(this IServiceCollection services, IConfiguration configuration)
        {
            string apiKey = configuration["X-Goog-Api-Key"];
            services.Configure<KeyOptions>(configuration.GetSection("GoogleMap"));
            services.AddSingleton<IGeocodingContext, GeocodingContext>();
            services.AddSingleton<IPlaceContext, PlaceContext>();
            services.AddSingleton<IRouteContext, RouteContext>();
            services.AddSingleton<IBaseInterceptor, Interceptor>();
            services.AddSingleton<IHttpRequest, HttpUtility>();
            services.AddSingleton<IGoogleMapAPIContext, GoogleMapContext>();
            return services;
        }
    }
}
