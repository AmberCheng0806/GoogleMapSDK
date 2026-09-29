using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Components
{
    public interface IReviewsView
    {
        double Rating { get; set; }
        List<IReviewView> ReviewsList { get; set; }
    }
}
