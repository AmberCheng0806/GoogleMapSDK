using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.AutoComplete
{
    public class Video
    {
        public string Title { get; set; }
        public string VideoId { get; set; }
        public Video(string title, string videoId)
        {
            this.Title = title;
            this.VideoId = videoId;
        }
    }
}
