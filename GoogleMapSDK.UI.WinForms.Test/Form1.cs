using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.UI.WinForms.Components.AutoComplete;
using IoC_Container.Attributes;

namespace GoogleMapSDK.UI.WinForms.Test
{
    public partial class Form1 : Form
    {
        private BaseAutoComplete<Place> Origin;
        private BaseAutoComplete<Video> VideoTest;
        public Form1(BaseAutoComplete<Place> origin, BaseAutoComplete<Video> videoTest)
        {
            InitializeComponent();
            Origin = origin;
            VideoTest = videoTest;
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Controls.Add(origin);
            flowLayoutPanel.Controls.Add(videoTest);
            origin.OnSelectedItem += OnSelectedItem;
            videoTest.OnSelectedItem += OnSelectedItem;
        }


        private void OnSelectedItem(object? sender, Place place)
        {
            MessageBox.Show(place.Name);
        }

        private void OnSelectedItem(object? sender, Video video)
        {
            MessageBox.Show(video.Title);
        }
    }
}
