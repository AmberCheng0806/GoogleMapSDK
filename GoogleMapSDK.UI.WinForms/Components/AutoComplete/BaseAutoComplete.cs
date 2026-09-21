using GoogleMapSDK.Contract.Contracts.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.UI.WinForms.Components.AutoComplete
{
    public abstract partial class BaseAutoComplete<T> : TextBox, IAutoCompleteView<T>
    {
        public event EventHandler<T> OnSelectedItem;
        private ListBox ListBox;
        public bool IsSelected { get; set; } = false;
        public abstract string DisplayMember { get; }
        public abstract string ValueMember { get; }

        public BaseAutoComplete()
        {
            ListBox = new ListBox();
            this.TextChanged += AutoCompleteTextBox_TextChanged;
            ListBox.MouseClick += ListBox_MouseClick;
        }


        public void ListBox_MouseClick(object sender, EventArgs e)
        {
            if (ListBox.SelectedItem == null) return;
            this.IsSelected = true;
            this.Text = ListBox.GetItemText(ListBox.SelectedItem);
            OnSelectedItem?.Invoke(this, (T)ListBox.SelectedItem);
            ResetListBox();
            this.IsSelected = false;
        }

        public async void AutoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.IsSelected) return;
            if (string.IsNullOrEmpty(this.Text)) return;
            var result = await GetSearchResults(this.Text);
            ListBox.DataSource = result;
            ListBox.DisplayMember = DisplayMember;
            ListBox.ValueMember = ValueMember;
            PositionAndShowListBox();
        }

        public abstract Task<IEnumerable<T>> GetSearchResults(string inputText);

    }
}
