using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Options;
using GoogleMapSDK.Core.Components.AutoComplete;
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
        public static IServiceCollection AddGoogleMapWinFormCoreService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAutoCompletePresenter<Place>, GoogleMapPresenter>();
            services.AddSingleton<IAutoCompletePresenter<Video>, YoutubePresenter>();
            services.AddSingleton<IYoutubeContext, YoutubeContext>();
            return services;
        }
    }
}
