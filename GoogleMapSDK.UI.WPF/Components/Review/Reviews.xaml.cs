using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Models.Review;
using GoogleMapSDK.Core.Components.Reviews;
using GoogleMapSDK.UI.WPF.Components.Review;
using IoC_Container.Factory;
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

namespace GoogleMapSDK.UI.WPF.Components.Review
{
    /// <summary>
    /// Reviews.xaml 的互動邏輯
    /// </summary>
    public partial class Reviews : UserControl
    {
        private ReviewsContext context;
        public Reviews(ReviewsContext reviewsContext)
        {
            InitializeComponent();
            context = reviewsContext;
            DataContext = context;
        }

        private string placeId;
        public string PlaceId
        {
            get => placeId;
            set
            {
                placeId = value;
                context.GetReviews(placeId);
            }
        }
    }
}
