using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Contracts.Presenter;
using GoogleMapSDK.Contract.Contracts.Service;
using GoogleMapSDK.Contract.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.Reviews
{
    public class ReviewsPresenter : IReviewsPresenter
    {
        private IPlaceDetailService PlaceDetailService;
        public ReviewsPresenter(IPlaceDetailService placeDetailService)
        {
            PlaceDetailService = placeDetailService;
        }
        public async Task<ReviewsModel> GetReviews(string placeId)
        {
            var detail = await PlaceDetailService.GetPlaceDetail(placeId);
            List<ReviewModel> reviews = detail.reviews?.Select(x => new ReviewModel(x.authorAttribution.displayName, x.authorAttribution.photoUri, x.rating, x.text?.text ?? "", x.relativePublishTimeDescription)).ToList() ?? new List<ReviewModel>();
            return new ReviewsModel(detail.rating, reviews);
        }

    }
}
