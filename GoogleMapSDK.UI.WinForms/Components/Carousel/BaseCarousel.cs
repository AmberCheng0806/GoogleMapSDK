using GoogleMapSDK.Contract.Contracts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForms.Components.Carousel
{
    public abstract class BaseCarousel : UserControl, ICarouselView
    {
        protected PictureBox PictureBox;
        protected Button PreviousBtn;
        protected Button NextBtn;
        protected List<string> images;
        public List<string> Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
                if (images == null || images.Count == 0) return;
                Index = 0;
                PictureBox.LoadAsync(images[Index]);
            }
        }
        protected int index = 0;
        public int Index { get => index; set => index = value; }

        public void NextBtn_Click(object sender, EventArgs e)
        {
            PreviousBtn.Enabled = true;
            Index++;
            if (Images.Count == 0 || Index == Images.Count - 1) NextBtn.Enabled = false;
            PictureBox.LoadAsync(images[Index]);
        }

        public void PreviousBtn_Click(object sender, EventArgs e)
        {
            NextBtn.Enabled = true;
            Index--;
            if (Images.Count == 0 || Index == 0) PreviousBtn.Enabled = false;
            PictureBox.LoadAsync(images[Index]);
        }
        public abstract Task GetImages(string placeId);
    }
}
