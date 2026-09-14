using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IAutoCompletePresenter<T>
    {
        Task<IEnumerable<T>> GetSearchResults(string inputText);
    }
}
