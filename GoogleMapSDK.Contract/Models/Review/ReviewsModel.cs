using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Review
{
    public class ReviewsModel
    {
        public double Rating { get; set; }
        public List<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();
        public int RatingCount { get; set; }

        public ReviewsModel(double rating, List<ReviewModel> reviews, int ratingCount)
        {
            Rating = rating;
            Reviews = reviews;
            RatingCount = ratingCount;
        }
    }
}
