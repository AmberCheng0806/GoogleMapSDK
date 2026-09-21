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
    public class YoutubeAutoCompleteTextBox : BaseAutoComplete<Video>
    {
        private IAutoCompletePresenter<Video> AutoCompletePresenter;
        public override string DisplayMember => "Title";
        public override string ValueMember => "VideoId";
        public YoutubeAutoCompleteTextBox(IPresenterFactory presenterFactory)
        {
            AutoCompletePresenter = presenterFactory.Create<IAutoCompletePresenter<Video>>(this);
        }
        public override async Task<IEnumerable<Video>> GetSearchResults(string inputText)
        {
            return await AutoCompletePresenter.GetSearchResults(inputText);
        }
    }
}
