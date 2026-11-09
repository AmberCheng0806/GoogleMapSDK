using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Service;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Options;
using GoogleMapSDK.Core.Components.AutoComplete;
using GoogleMapSDK.Core.Components.Carousel;
using GoogleMapSDK.Core.Components.GMap;
using GoogleMapSDK.Core.Components.PlaceCard;
using GoogleMapSDK.Core.Components.Reviews;
using GoogleMapSDK.Core.Components.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeAPI;
using YoutubeAPI.Interfaces;

namespace GoogleMapSDK.Core
{
    public static class GoogleMapWinFormCoreRegistration
    {
        public static IServiceCollection AddGoogleMapCoreService(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddSingleton<IAutoCompletePresenter<Place>, GoogleMapPresenter>();
            services.AddSingleton<IAutoCompletePresenter<Video>, YoutubePresenter>();
            services.AddSingleton<ICarousePresenter, CarouselPresenter>();
            services.AddSingleton<IReviewsPresenter, ReviewsPresenter>();
            services.AddSingleton<IPlaceCardPresenter, PlaceCardPresenter>();
            services.AddSingleton<IGMapPresenter, GMapPresenter>();
            services.AddSingleton<IPlaceDetailService, PlaceDetailService>();
            services.AddSingleton<IYoutubeContext, YoutubeContext>();
            return services;
        }
    }
}
