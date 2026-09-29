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
    public partial class Review : BaseReview
    {
        public override string AuthorName
        {
            get
            {
                return authorName;
            }
            set
            {
                authorName = value;
                AuthorNameLab.Text = authorName;
            }
        }
        public override string AuthorImg
        {
            get
            {
                return authorImg;
            }
            set
            {
                authorImg = value;
                if (!string.IsNullOrEmpty(value))
                {
                    pictureBox1.LoadAsync(value);
                }
            }
        }
        public override int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                RatingLab.Text = rating.ToString();
                RenderStars(rating);
            }
        }
        public override string ReviewText
        {
            get
            {
                return reviewText;
            }
            set
            {
                reviewText = value;
                ReviewTextLab.Text = reviewText;
            }
        }
        public override string PublishTime
        {
            get
            {
                return publishTime;
            }
            set
            {
                publishTime = value;
                publishTimeLab.Text = publishTime.ToString();
            }
        }

        public Review() { InitializeComponent(); }
        private void RenderStars(int number)
        {
            StarLab.Text = "";
            for (int i = 0; i < number; i++)
            {
                StarLab.Text += "★";
            }
            int rest = 5 - number;
            for (int i = 0; i < rest; i++)
            {
                StarLab.Text += "☆";
            }
        }
    }
}
