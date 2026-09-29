using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.Presenter
{
    public interface ICarousePresenter
    {
        Task<List<string>> GetImages(string placeId);
    }
}
