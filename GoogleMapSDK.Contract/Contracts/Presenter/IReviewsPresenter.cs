using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Presenter
{
    public interface IReviewsPresenter
    {
        Task<ReviewsModel> GetReviews(string placeId);
    }
}
