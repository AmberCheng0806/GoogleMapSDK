using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Components
{
    public interface ICarouselView
    {
        List<string> Images { get; set; }
        int Index { get; set; }
        void PreviousBtn_Click(object sender, EventArgs e);
        void NextBtn_Click(object sender, EventArgs e);
    }
}
