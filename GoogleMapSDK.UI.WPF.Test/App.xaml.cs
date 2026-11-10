using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using GoogleMapSDK.API;
using GoogleMapSDK.Core;
using GoogleMapSDK.UI.WPF.Components.Carousel;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.UI.WPF.Components.GMap;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.Review;
using GoogleMapSDK.Contract.Models.AutoComplete;

namespace GoogleMapSDK.UI.WPF.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IoC_Container.ServiceProvider ServiceProvider;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var service = new IoC_Container.ServiceCollection();
            service.AddGoogleMapWPFService(config);
            service.AddGoogleMapCoreService(config);
            service.AddGoogleMapAPIService(config);
            service.AddSingleton<MainWindow, MainWindow>();


            var provider = service.BuildServiceProvider();
            ServiceProvider = provider;
            var mainWindow = (MainWindow)provider.GetService(typeof(MainWindow));
            mainWindow.Show();
        }
    }

}
