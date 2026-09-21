using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Options;
using GoogleMapSDK.UI.WinForms.Components.AutoComplete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapSDK.UI.WinForms
{
    public static class GoogleMapWinFormRegistration
    {
        public static IServiceCollection AddGoogleMapWinFormService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<BaseAutoComplete<Place>, GoogleMapAutoCompleteTextBox>();
            services.AddSingleton<BaseAutoComplete<Video>, YoutubeAutoCompleteTextBox>();

            return services;
        }
    }
}
