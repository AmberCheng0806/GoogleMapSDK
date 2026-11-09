using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.Carousel;
using GoogleMapSDK.UI.WPF.Components.GMap;
using GoogleMapSDK.UI.WPF.Components.PlaceCard;
using GoogleMapSDK.UI.WPF.Components.Review;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF
{
    public static class GoogleMapWPFRegistration
    {
        public static IServiceCollection AddGoogleMapWPFService(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddSingleton<BaseAutoComplete<Place>, GoogleMapAutoCompleteTextBox>();
            services.AddSingleton<BaseAutoComplete<Video>, YoutubeAutoCompleteTextBox>();
            services.AddSingleton<Carousel, Carousel>();
            services.AddSingleton<Reviews, Reviews>();
            services.AddSingleton<Components.GMap.GMap, Components.GMap.GMap>();
            services.AddSingleton<PlaceCard, PlaceCard>();
            services.AddSingleton<IReviewsView, ReviewsContext>();
            services.AddSingleton<ICarouselView, CarouselContext>();
            services.AddSingleton<IPlaceCardView, PlaceCardContext>();
            services.AddSingleton<IGMapView, GMapContext>();
            return services;
        }
    }
}
