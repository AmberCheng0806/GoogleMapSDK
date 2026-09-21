using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF.Components.AutoComplete
{
    /// <summary>
    /// AutoCompleteTextBox.xaml 的互動邏輯
    /// </summary>
    public partial class AutoCompleteTextBox : UserControl
    {
        public AutoCompleteTextBox()
        {
            InitializeComponent();
        }

        public Visibility IsDropDownVisible
        {
            get => (Visibility)GetValue(IsDropDownVisibleProperty);
            set => SetValue(IsDropDownVisibleProperty, value);
        }

        public static readonly DependencyProperty IsDropDownVisibleProperty =
            DependencyProperty.Register(
                nameof(IsDropDownVisible),
                typeof(Visibility),
                typeof(AutoCompleteTextBox),
                new PropertyMetadata(Visibility.Collapsed));

    }
}

