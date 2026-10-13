using GoogleMapSDK.Contract.Contracts.Components;
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
    public class ReviewContext : IReviewView
    {
        public string AuthorName { get; set; }
        public string AuthorImg { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string PublishTime { get; set; }
        public string Stars { get; set; }
        public ReviewContext()
        {

        }
        public ReviewContext(string authorName, string authorImg, int rating, string reviewText, string time)
        {
            AuthorName = authorName;
            AuthorImg = authorImg;
            Rating = rating;
            ReviewText = reviewText;
            PublishTime = time;
            RenderStars(rating);
        }
        private void RenderStars(int number)
        {
            Stars = "";
            for (int i = 0; i < number; i++)
            {
                Stars += "★";
            }
            int rest = 5 - number;
            for (int i = 0; i < rest; i++)
            {
                Stars += "☆";
            }
        }

    }
}
