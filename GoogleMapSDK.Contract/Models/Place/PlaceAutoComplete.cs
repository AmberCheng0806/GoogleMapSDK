using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models.Place
{
    public class PlaceAutoComplete
    {

        public Suggestion[] suggestions { get; set; }


        public class Suggestion
        {
            public Placeprediction placePrediction { get; set; }
        }

        public class Placeprediction
        {
            public string place { get; set; }
            public string placeId { get; set; }
            public Text text { get; set; }
            public Structuredformat structuredFormat { get; set; }
            public string[] types { get; set; }
        }

        public class Text
        {
            public string text { get; set; }
            public Match[] matches { get; set; }
        }

        public class Match
        {
            public int startOffset { get; set; }
            public int endOffset { get; set; }
        }

        public class Structuredformat
        {
            public Maintext mainText { get; set; }
            public Secondarytext secondaryText { get; set; }
        }

        public class Maintext
        {
            public string text { get; set; }
            public Match1[] matches { get; set; }
        }

        public class Match1
        {
            public int endOffset { get; set; }
            public int startOffset { get; set; }
        }

        public class Secondarytext
        {
            public string text { get; set; }
        }

    }
}
