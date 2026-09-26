using GoogleMapSDK.Contract.Contracts.API;
using GoogleMapSDK.Contract.Models.AutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YoutubeAPI.Interfaces;

namespace GoogleMapSDK.Core.Components.AutoComplete
{
    public class YoutubePresenter : IAutoCompletePresenter<Video>
    {
        private IYoutubeContext YoutubeContext;
        public YoutubePresenter(IYoutubeContext youtubeContext)
        {
            YoutubeContext = youtubeContext;
        }

        public async Task<IEnumerable<Video>> GetSearchResults(string inputText)
        {
            var search = await YoutubeContext.Search.GetAllAsync(inputText, 0, default);
            if (search.items.Count() == 0) return null;
            return search.items.Select(x => new Video(x.snippet.title, x.id.videoId)).ToList();
        }
    }
}
