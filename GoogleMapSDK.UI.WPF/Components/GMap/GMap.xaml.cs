using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Contracts.Components;

namespace GoogleMapSDK.UI.WPF.Components.GMap
{
    /// <summary>
    /// GMap.xaml 的互動邏輯
    /// </summary>
    public partial class GMap : UserControl
    {
        private GMapControl gMapControl = new GMapControl();
        private PlaceCard.PlaceCard PlaceCard;
        private IGMapView GMapContext;
        public GMap(PlaceCard.PlaceCard placeCard, IGMapView gMapContext)
        {
            InitializeComponent();
            PlaceCard = placeCard;
            GMapContext = gMapContext;
            DataContext = GMapContext;
            GMapPanel.Children.Add(gMapControl);
            gMapControl.Width = GMapPanel.Width;
            gMapControl.Height = GMapPanel.Height;
            //设置地图源
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            //地图中心位置
            this.gMapControl.Position = new PointLatLng(25.0420, 121.5700);
            //缩放级别
            this.gMapControl.MaxZoom = 25;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.Zoom = 16;
            gMapControl.MouseLeftButtonDown += mapControl_MouseLeftButtonDown;
        }

        void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gMapControl.Markers.Clear();
            Point clickPoint = e.GetPosition(gMapControl);
            PointLatLng point = gMapControl.FromLocalToLatLng((int)clickPoint.X, (int)clickPoint.Y);
            Image image = new Image
            {
                Width = 20,
                Height = 34,
                Source = new BitmapImage(new Uri("D://搬家/red-dot.png"))
            };
            image.ToolTip = new Button()
            {
                Content = new TextBox(),
            };
            GMapMarker marker = new GMapMarker(point)
            {
                Shape = image,

                // 水滴型圖片：底部尖端對準座標
                Offset = new Point(-10, -34)
            }; ;
            gMapControl.Markers.Add(marker);
        }
        public async Task GetGMapDatas(string placeId)
        {
            var location = await GMapContext.GetGMapDatas(placeId);
            PointLatLng point = new PointLatLng(location.Lat, location.Lng);
            await PlaceCard.LoadAsync(placeId);
            var toolTip = new ToolTip
            {
                Content = PlaceCard,
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
                Background = Brushes.Transparent,
                HasDropShadow = false
            };
            Image image = new Image
            {
                Width = 20,
                Height = 34,
                Source = new BitmapImage(new Uri("D://搬家/red-dot.png")),
                ToolTip = toolTip
            };
            GMapMarker marker = new GMapMarker(point)
            {
                Shape = image,
                // 水滴型圖片：底部尖端對準座標
                Offset = new Point(-10, -34)
            }; ;
            gMapControl.Markers.Add(marker);
            gMapControl.Position = point;
        }
    }
}
