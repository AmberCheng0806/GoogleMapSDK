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
        //private string authorName;
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
        //private string authorImg;
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
        //private int rating;
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
        //private string reviewText;
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
        //private string publishTime;
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

        //public Review(string authorName, string authorImg, int rating, string reviewText, string time) : this()
        //{
        //    AuthorName = authorName;
        //    AuthorImg = authorImg;
        //    Rating = rating;
        //    ReviewText = reviewText;
        //    PublishTime = time;
        //}
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
