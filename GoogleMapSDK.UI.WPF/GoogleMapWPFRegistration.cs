using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
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
        public static IServiceCollection AddGoogleMapWPFService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<BaseAutoComplete<Place>, GoogleMapAutoCompleteTextBox>();
            services.AddSingleton<BaseAutoComplete<Video>, YoutubeAutoCompleteTextBox>();

            return services;
        }
    }
}
