using GoogleMapSDK.Contract.Contracts.Components;
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

namespace GoogleMapSDK.UI.WPF.Components.PlaceCard
{
    /// <summary>
    /// PlaceCard.xaml 的互動邏輯
    /// </summary>
    public partial class PlaceCard : UserControl
    {
        private readonly IPlaceCardView PlaceCardContext;
        private Carousel.Carousel Carousel;
        public PlaceCard(IPlaceCardView placeCardContext)
        {
            InitializeComponent();
            PlaceCardContext = placeCardContext;
            DataContext = PlaceCardContext;
        }
        public async Task LoadAsync(string placeId)
        {
            await PlaceCardContext.GetPlaceCard(placeId);
        }
    }
}
