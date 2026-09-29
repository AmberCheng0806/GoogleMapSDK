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

        public ReviewsModel(double rating, List<ReviewModel> reviews)
        {
            Rating = rating;
            Reviews = reviews;
        }
    }
}
