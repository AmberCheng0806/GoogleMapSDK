using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Review
{
    public class ReviewModel
    {
        public string AuthorName { get; set; }
        public string AuthorImg { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string PublishTime { get; set; }
        public ReviewModel(string authorName, string authorImg, int rating, string reviewText, string time)
        {
            AuthorName = authorName;
            AuthorImg = authorImg;
            Rating = rating;
            ReviewText = reviewText;
            PublishTime = time;
        }
        public ReviewModel() { }
    }
}
