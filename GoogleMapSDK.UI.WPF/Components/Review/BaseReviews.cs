using GoogleMapSDK.Contract.Contracts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoogleMapSDK.UI.WPF.Components.Review
{
    public abstract class BaseReviews : UserControl, IReviewsView
    {
        protected double rating;
        public virtual double Rating
        {
            get => rating;
            set => rating = value;
        }

        protected List<IReviewView> reviewsList = new List<IReviewView>();
        public virtual List<IReviewView> ReviewsList
        {
            get => reviewsList;
            set => reviewsList = value;
        }

        public abstract Task GetReviews(string placeId);
    }
}
