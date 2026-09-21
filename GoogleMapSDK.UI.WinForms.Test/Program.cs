using GoogleMapSDK.API;
using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Options;
using GoogleMapSDK.Core;
using GoogleMapSDK.Core.Components.AutoComplete;
using GoogleMapSDK.UI.WinForms.Components.AutoComplete;
using HTTP_Utility.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace GoogleMapSDK.UI.WinForms.Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var service = new IoC_Container.ServiceCollection();
            service.AddGoogleMapWinFormService(config);
            service.AddGoogleMapWinFormCoreService(config);
            service.AddGoogleMapAPIService(config);
            service.AddSingleton<Form1, Form1>();

            var provider = service.BuildServiceProvider();
            var form = (Form1)provider.GetService(typeof(Form1));
            Application.Run(form);
        }
    }
}