using GoogleMapSDK.Contract.Contracts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForms.Components.Reviews
{
    public class BaseReview : UserControl, IReviewView
    {
        protected string authorName;
        public virtual string AuthorName
        {
            get => authorName;
            set => authorName = value;
        }

        protected string authorImg;
        public virtual string AuthorImg
        {
            get => authorImg;
            set => authorImg = value;
        }

        protected int rating;
        public virtual int Rating
        {
            get => rating;
            set => rating = value;
        }

        protected string reviewText;
        public virtual string ReviewText
        {
            get => reviewText;
            set => reviewText = value;
        }

        protected string publishTime;
        public virtual string PublishTime
        {
            get => publishTime;
            set => publishTime = value;
        }
    }
}
