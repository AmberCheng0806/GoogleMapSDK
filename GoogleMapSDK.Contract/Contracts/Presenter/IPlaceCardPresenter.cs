using GoogleMapSDK.Contract.Models.PlaceCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Presenter
{
    public interface IPlaceCardPresenter
    {
        Task<PlaceCard> GetPlaceCard(string placeId);
    }
}
