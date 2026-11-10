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

            // 搜尋框：兩個之間留點間距。
            // 後面的下拉清單會蓋住前面的，所以讓排在前面的 ZIndex 較高
            origin.Margin = new Thickness(0, 0, 0, 8);
            Panel.SetZIndex(origin, 2);
            Panel.SetZIndex(videoTest, 1);
            AutoCompletePanel.Children.Add(origin);
            AutoCompletePanel.Children.Add(videoTest);

            // 輪播、地圖、評論放到各自的區塊
            CarouselHost.Child = carousel;
            gMap.Height = double.NaN;   // 高度交給外層 Border 控制
            GMapHost.Child = gMap;
            ReviewsHost.Child = reviews;

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