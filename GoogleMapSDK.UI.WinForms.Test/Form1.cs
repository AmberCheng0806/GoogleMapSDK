using GoogleMapSDK.API;
using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Contract.Models.Review;
using GoogleMapSDK.UI.WinForms.Components.AutoComplete;
using GoogleMapSDK.UI.WinForms.Components.Carousel;
using GoogleMapSDK.UI.WinForms.Components.Reviews;
using IoC_Container.Attributes;
using IoC_Container.Factory;

namespace GoogleMapSDK.UI.WinForms.Test
{
    public partial class Form1 : Form
    {
        private BaseAutoComplete<Place> Origin;
        private BaseAutoComplete<Video> VideoTest;
        private BaseCarousel Carousel;
        private BaseReviews Reviews;
        public Form1(BaseAutoComplete<Place> origin, BaseAutoComplete<Video> videoTest, BaseCarousel carousel, BaseReviews reviews)
        {
            InitializeComponent();
            Origin = origin;
            VideoTest = videoTest;
            Carousel = carousel;
            Reviews = reviews;
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Controls.Add(origin);
            flowLayoutPanel.Controls.Add(videoTest);
            flowLayoutPanel.Controls.Add(carousel);
            flowLayoutPanel.Controls.Add(reviews);
            origin.OnSelectedItem += OnSelectedItem;
            videoTest.OnSelectedItem += OnSelectedItem;
        }

        private async void OnSelectedItem(object? sender, Place place)
        {
            string placeId = place.Value;
            await Reviews.GetReviews(placeId);
            await Carousel.GetImages(placeId);
        }

        private void OnSelectedItem(object? sender, Video video)
        {
            MessageBox.Show(video.Title);
        }
    }
}
