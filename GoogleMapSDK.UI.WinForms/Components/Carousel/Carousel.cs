using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using IoC_Container.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForms.Components.Carousel
{
    public partial class Carousel : UserControl, ICarouselView
    {
        private ICarousePresenter CarousePresenter;
        private PictureBox PictureBox;
        private Button PreviousBtn;
        private Button NextBtn;
        public Carousel(IPresenterFactory presenterFactory)
        {
            InitializeComponent();
            PreviousBtn = button1;
            NextBtn = button2;
            PictureBox = pictureBox1;
            PreviousBtn.Enabled = false;
            PreviousBtn.Click += PreviousBtn_Click;
            NextBtn.Click += NextBtn_Click;
            CarousePresenter = presenterFactory.Create<ICarousePresenter>(this);
        }

        protected List<string> images;
        public List<string> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value ?? new List<string>();
                if (images == null || images.Count == 0) return;
                Index = 0;
                PreviousBtn.Enabled = false;
                NextBtn.Enabled = images.Count > 1;
                PictureBox.LoadAsync(images[Index]);
            }
        }
        private int index = 0;
        public int Index { get => index; set => index = value; }

        public async Task GetImages(string placeId)
        {
            var result = await CarousePresenter.GetImages(placeId);
            Images = result;
        }

        public void Next()
        {
            PreviousBtn.Enabled = true;
            Index++;
            if (Images.Count == 0 || Index == Images.Count - 1) NextBtn.Enabled = false;
            PictureBox.LoadAsync(images[Index]);
        }

        public void Previous()
        {
            NextBtn.Enabled = true;
            Index--;
            if (Images.Count == 0 || Index == 0) PreviousBtn.Enabled = false;
            PictureBox.LoadAsync(images[Index]);
        }
        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            Previous();
        }
        private void NextBtn_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
