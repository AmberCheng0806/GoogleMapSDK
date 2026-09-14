using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Contracts.API
{
    public interface IAutoCompleteView<T>
    {
        event EventHandler<T> OnSelectedItem;
        bool IsSelected { get; set; }
        string DisplayMember { get; }
        string ValueMember { get; }
        void ListBox_MouseClick(object sender, EventArgs e);
        void AutoCompleteTextBox_TextChanged(object sender, EventArgs e);
        Task<IEnumerable<T>> GetSearchResults(string inputText);
    }
}
