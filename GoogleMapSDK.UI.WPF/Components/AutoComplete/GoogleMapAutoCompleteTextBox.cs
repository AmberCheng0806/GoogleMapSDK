using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.Core.Components.AutoComplete;
using IoC_Container.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    public class GoogleMapAutoCompleteTextBox : BaseAutoComplete<Place>
    {
        private IAutoCompletePresenter<Place> AutoCompletePresenter;
        public override string DisplayMember => "Name";
        public override string ValueMember => "Value";
        public GoogleMapAutoCompleteTextBox(IPresenterFactory presenterFactory)
        {
            AutoCompletePresenter = presenterFactory.Create<IAutoCompletePresenter<Place>>(this);
        }
        public override async Task<IEnumerable<Place>> GetSearchResults(string inputText)
        {
            return await AutoCompletePresenter.GetSearchResults(inputText);
        }
    }
}
