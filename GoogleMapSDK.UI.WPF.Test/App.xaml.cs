using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using GoogleMapSDK.API;
using GoogleMapSDK.Core;

namespace GoogleMapSDK.UI.WPF.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            var service = new IoC_Container.ServiceCollection();
            service.AddGoogleMapWPFService(config);
            service.AddGoogleMapWinFormCoreService(config);
            service.AddGoogleMapAPIService(config);
            service.AddSingleton<MainWindow, MainWindow>();

            var provider = service.BuildServiceProvider();
            var mainWindow = (MainWindow)provider.GetService(typeof(MainWindow));
            mainWindow.Show();
        }
    }

}
