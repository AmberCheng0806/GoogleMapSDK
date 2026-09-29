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
    public partial class Reviews : BaseReviews
    {
        private IReviewsPresenter ReviewsPresenter;
        public override double Rating
        {
            get => rating;
            set
            {
                rating = value;
                RatingText.Text = Math.Round(value, 1).ToString();
                RenderStars(value);
            }
        }

        public override List<IReviewView> ReviewsList
        {
            get => reviewsList;
            set
            {
                reviewsList = value;
                RenderReviews();
            }
        }

        public Reviews(IPresenterFactory presenterFactory)
        {
            InitializeComponent();
            ReviewsPresenter = presenterFactory.Create<IReviewsPresenter>(this);
        }

        private void RenderStars(double number)
        {
            if (ReviewsList.Count == 0) return;
            StarText.Text = "";
            int num = (int)Math.Round(number);
            for (int i = 0; i < num; i++)
            {
                StarText.Text += "★";
            }
            int rest = 5 - num;
            for (int i = 0; i < rest; i++)
            {
                StarText.Text += "☆";
            }
        }

        private void RenderReviews()
        {
            ReviewsPanel.Children.Clear();
            foreach (IReviewView review in ReviewsList)
            {
                ReviewsPanel.Children.Add((Control)review);
            }
        }

        public async override Task GetReviews(string placeId)
        {
            var reviews = await ReviewsPresenter.GetReviews(placeId);
            ReviewsList = AutoMapper.AutoMapper.Map<ReviewModel, Review>(reviews.Reviews).Select(x => (IReviewView)x).ToList();
            Rating = reviews.Rating;
        }
    }
}
