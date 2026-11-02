using GoogleMapSDK.Contract.Contracts.Components;
using GoogleMapSDK.Contract.Models.AutoComplete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    public abstract class BaseAutoComplete<T> : AutoCompleteTextBox, IAutoCompleteView<T>
    {
        public bool IsSelected { get; set; } = false;
        public abstract string DisplayMember { get; }
        public abstract string ValueMember { get; }
        private CancellationTokenSource Cancellation;

        public event EventHandler<T> OnSelectedItem;

        public BaseAutoComplete()
        {
            AutoComplete.TextChanged += AutoCompleteTextBox_TextChanged;
            ResultListBox.SelectionChanged += ListBox_MouseClick;
        }
        public async void AutoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.IsSelected) return;
                if (string.IsNullOrEmpty(AutoComplete.Text))
                {
                    IsDropDownVisible = System.Windows.Visibility.Collapsed;
                    return;
                }
                Cancellation?.Cancel();
                Cancellation = new CancellationTokenSource();
                await Task.Delay(600, Cancellation.Token);
                var result = await GetSearchResults(AutoComplete.Text);
                ResultListBox.ItemsSource = result;
                ResultListBox.DisplayMemberPath = DisplayMember;
                ResultListBox.SelectedValuePath = ValueMember;
                IsDropDownVisible = System.Windows.Visibility.Visible;
            }
            catch (Exception ex)
            {
            }
        }

        public void ListBox_MouseClick(object sender, EventArgs e)
        {
            if (ResultListBox.SelectedItem == null) return;
            this.IsSelected = true;
            AutoComplete.Text = ResultListBox.SelectedItem.GetType().GetProperty(DisplayMember).GetValue(ResultListBox.SelectedItem).ToString();
            OnSelectedItem?.Invoke(this, (T)ResultListBox.SelectedItem);
            IsDropDownVisible = System.Windows.Visibility.Collapsed;
            this.IsSelected = false;
        }
        public abstract Task<IEnumerable<T>> GetSearchResults(string inputText);
    }
}
