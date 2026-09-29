using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Components
{
    public interface IReviewView
    {
        string AuthorName { get; set; }
        string AuthorImg { get; set; }
        int Rating { get; set; }
        string ReviewText { get; set; }
        string PublishTime { get; set; }
    }
}
