using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Models.Review;
using Newtonsoft.Json.Linq;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.Review
{
    [AddINotifyPropertyChangedInterface]
    public class ReviewsContext : IReviewsView
    {
        private IReviewsPresenter ReviewsPresenter;

        public double Rating { get; set; }
        public List<IReviewView> ReviewsList { get; set; } = new List<IReviewView>();
        public string Stars { get; set; }
        public ReviewsContext(IReviewsPresenter reviewsPresenter)
        {
            ReviewsPresenter = reviewsPresenter;
        }

        public async Task GetReviews(string placeId)
        {
            var reviews = await ReviewsPresenter.GetReviews(placeId);
            ReviewsList.Clear();
            ReviewsList = AutoMapper.AutoMapper.Map<ReviewModel, ReviewContext>(reviews.Reviews).Select(x => (IReviewView)x).ToList();
            Rating = reviews.Rating;
            RenderStars(Rating);
        }
        private void RenderStars(double number)
        {
            if (ReviewsList.Count == 0) return;
            Stars = "";
            int num = (int)Math.Round(number);
            for (int i = 0; i < num; i++)
            {
                Stars += "★";
            }
            int rest = 5 - num;
            for (int i = 0; i < rest; i++)
            {
                Stars += "☆";
            }
        }
    }
}
