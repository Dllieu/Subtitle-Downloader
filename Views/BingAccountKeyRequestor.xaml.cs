using SubtitlesDownloaderWPF.SearchStrategies.Bing;
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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace SubtitlesDownloaderWPF.Views
{
    /// <summary>
    /// Interaction logic for BingAccountKeyRequestor.xaml
    /// </summary>
    public partial class BingAccountKeyRequestor : Window
    {
        public BingAccountKeyRequestor()
        {
            InitializeComponent();
        }

        public string BingAccountKey
        {
            get { return AccountKey.Text; }
        }

        /// <summary>
        /// CheckBingAccountKey
        /// </summary>
        private bool CheckBingAccountKey()
        {
            if (string.IsNullOrEmpty(BingAccountKey))
                return false;

            try
            {
                var bingRequestor = new BingRequestor(BingAccountKey);
                bingRequestor.ExecuteQueryInWeb("bing");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ValidateForm
        /// </summary>
        private void ValidateForm(object sender, RoutedEventArgs e)
        {
            if (!CheckBingAccountKey())
                MessageBox.Show("Invalid credential", "Invalid Credential", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                DialogResult = true;
        }

        private void CancelForm(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /// GetBingKey
        private void GoToHyperlink(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
