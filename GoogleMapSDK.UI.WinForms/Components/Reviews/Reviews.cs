using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Models.Review;
using GoogleMapSDK.Core.Components.Reviews;
using IoC_Container.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForms.Components.Reviews
{
    public partial class Reviews : BaseReviews
    {
        private IReviewsPresenter ReviewsPresenter;
        public override double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                RatingLab.Text = Math.Round(rating, 1).ToString();
                RenderStars(rating);
            }
        }
        public override List<IReviewView> ReviewsList
        {
            get
            {
                return reviewsList;
            }
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
            if (reviewsList.Count == 0) return;
            StarLab.Text = "";
            int num = (int)Math.Round(number);
            for (int i = 0; i < num; i++)
            {
                StarLab.Text += "★";
            }
            int rest = 5 - num;
            for (int i = 0; i < rest; i++)
            {
                StarLab.Text += "☆";
            }
        }

        private void RenderReviews()
        {
            ReviewsPanel.Controls.Clear();
            foreach (IReviewView review in reviewsList)
            {
                ReviewsPanel.Controls.Add((Control)review);
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
