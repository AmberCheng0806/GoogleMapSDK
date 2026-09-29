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
    public partial class Carousel : BaseCarousel
    {
        private ICarousePresenter CarousePresenter;
        public Carousel(IPresenterFactory presenterFactory)
        {
            InitializeComponent();
            PreviousBtn = button1;
            NextBtn = button2;
            PictureBox = pictureBox1;
            PreviousBtn.Enabled = false;
            CarousePresenter = presenterFactory.Create<ICarousePresenter>(this);
        }

        public override async Task GetImages(string placeId)
        {
            var result = await CarousePresenter.GetImages(placeId);
            Images = result;
        }
    }
}
