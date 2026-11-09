using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.Carousel;
using GoogleMapSDK.UI.WPF.Components.Review;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Carousel Carousel;
        private Reviews Reviews;
        private Components.GMap.GMap GMap;
        public MainWindow(BaseAutoComplete<Place> origin, BaseAutoComplete<Video> videoTest, Carousel carousel, Reviews reviews, Components.GMap.GMap gMap)
        {
            InitializeComponent();
            origin.OnSelectedItem += OnSelectedItem;
            videoTest.OnSelectedItem += OnSelectedItem;
            AutoCompletePanel.Children.Add(origin);
            AutoCompletePanel.Children.Add(videoTest);
            AutoCompletePanel.Children.Add(carousel);
            gMap.Height = 400;
            AutoCompletePanel.Children.Add(gMap);
            AutoCompletePanel.Children.Add(reviews);
            Carousel = carousel;
            Reviews = reviews;
            GMap = gMap;
        }
        private void OnSelectedItem(object? sender, Video e)
        {
            MessageBox.Show(e.Title);
        }

        private async void OnSelectedItem(object? sender, Place e)
        {
            string placeId = e.Value;
            Reviews.PlaceId = placeId;
            Carousel.PlaceId = placeId;
            await GMap.GetGMapDatas(placeId);
        }
    }
}