using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.UI.WPF.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GoogleMapSDK.UI.WPF.Components.Carousel
{
    [AddINotifyPropertyChangedInterface]
    public class CarouselContext : ICarouselView
    {
        private ICarousePresenter CarousePresenter;
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public List<string> Images { get; set; }
        public string CurrentImage { get; set; }
        public int Index { get; set; }
        public bool IsPrevious { get; set; } = false;
        public bool IsNext { get; set; } = true;

        public CarouselContext(ICarousePresenter carousePresenter)
        {
            CarousePresenter = carousePresenter;
            PreviousCommand = new RelayCommand(() => Previous());
            NextCommand = new RelayCommand(() => Next());
        }
        public async Task GetImages(string placeId)
        {
            var result = await CarousePresenter.GetImages(placeId);
            Images = result;
            CurrentImage = Images[0];
        }

        public void Previous()
        {
            IsNext = true;
            Index--;
            if (Images.Count == 0 || Index == 0) IsPrevious = false;
            CurrentImage = Images[Index];
        }

        public void Next()
        {
            IsPrevious = true;
            Index++;
            if (Images.Count == 0 || Index == Images.Count - 1) IsNext = false;
            CurrentImage = Images[Index];
        }
    }
}
