using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoogleMapSDK.UI.WPF.Components.Review;

namespace GoogleMapSDK.UI.WPF.Components.Review
{
    /// <summary>
    /// Review.xaml 的互動邏輯
    /// </summary>
    public partial class Review : BaseReview
    {
        public override string AuthorName
        {
            get => authorName;
            set
            {
                authorName = value;
                AuthorNameText.Text = value;
            }
        }

        public override string AuthorImg
        {
            get => authorImg;
            set
            {
                authorImg = value;
                if (string.IsNullOrEmpty(value)) return;
                AuthorImage.Source = new BitmapImage(new Uri(value, UriKind.Absolute));
            }
        }

        public override int Rating
        {
            get => rating;
            set
            {
                rating = value;
                RatingText.Text = value.ToString();
                RenderStars(value);
            }
        }

        public override string ReviewText
        {
            get => reviewText;
            set
            {
                reviewText = value;
                ReviewTextBlock.Text = value;
            }
        }

        public override string PublishTime
        {
            get => publishTime;
            set
            {
                publishTime = value;
                PublishTimeText.Text = value;
            }
        }

        public Review(string authorName, string authorImg, int rating, string reviewText, string time) : this()
        {
            AuthorName = authorName;
            AuthorImg = authorImg;
            Rating = rating;
            ReviewText = reviewText;
            PublishTime = time;
        }

        public Review()
        {
            InitializeComponent();
        }

        private void RenderStars(int number)
        {
            StarText.Text = "";
            for (int i = 0; i < number; i++)
            {
                StarText.Text += "★";
            }
            int rest = 5 - number;
            for (int i = 0; i < rest; i++)
            {
                StarText.Text += "☆";
            }
        }
    }
}
