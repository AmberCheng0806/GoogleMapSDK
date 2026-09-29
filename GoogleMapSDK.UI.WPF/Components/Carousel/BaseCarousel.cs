using GoogleMapSDK.Contract.Contracts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GoogleMapSDK.UI.WPF.Components.Carousel
{
    public abstract class BaseCarousel : UserControl, ICarouselView
    {
        protected Image Image;
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
                Image.Source = new BitmapImage(new Uri(images[Index], UriKind.Absolute));
            }
        }
        protected int index = 0;
        public int Index { get => index; set => index = value; }

        public void NextBtn_Click(object sender, EventArgs e)
        {
            PreviousBtn.IsEnabled = true;
            Index++;
            if (Images.Count == 0 || Index == Images.Count - 1) NextBtn.IsEnabled = false;
            Image.Source = new BitmapImage(new Uri(images[Index], UriKind.Absolute));
        }

        public void PreviousBtn_Click(object sender, EventArgs e)
        {
            NextBtn.IsEnabled = true;
            Index--;
            if (Images.Count == 0 || Index == 0) PreviousBtn.IsEnabled = false;
            Image.Source = new BitmapImage(new Uri(images[Index], UriKind.Absolute));
        }

        public abstract Task GetImages(string placeId);
    }
}
