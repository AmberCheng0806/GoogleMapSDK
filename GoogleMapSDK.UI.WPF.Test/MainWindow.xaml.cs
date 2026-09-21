using GoogleMapSDK.Contract.Models.AutoComplete;
using GoogleMapSDK.UI.WPF.Components.AutoComplete;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.UI.WPF.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(BaseAutoComplete<Place> origin, BaseAutoComplete<Video> videoTest)
        {
            InitializeComponent();
            origin.OnSelectedItem += OnSelectedItem;
            videoTest.OnSelectedItem += OnSelectedItem;
            AutoCompletePanel.Children.Add(origin);
            AutoCompletePanel.Children.Add(videoTest);

        }
        private void OnSelectedItem(object? sender, Video e)
        {
            MessageBox.Show(e.Title);
        }

        private void OnSelectedItem(object? sender, Place e)
        {
            MessageBox.Show(e.Name);
        }
    }
}