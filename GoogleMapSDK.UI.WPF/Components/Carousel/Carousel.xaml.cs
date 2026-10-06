using GoogleMapSDK.Contract.Contracts.Presenter;
using IoC_Container.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GoogleMapSDK.UI.WPF.Components.Carousel
{
    /// <summary>
    /// Carousel.xaml 的互動邏輯
    /// </summary>
    public partial class Carousel : UserControl
    {
        private CarouselContext context;
        public Carousel(CarouselContext carouselContext)
        {
            InitializeComponent();
            context = carouselContext;
            DataContext = carouselContext;
        }
        private string placeId;
        public string PlaceId
        {
            get => placeId;
            set
            {
                placeId = value;
                context.GetImages(placeId);
            }
        }
    }
}
