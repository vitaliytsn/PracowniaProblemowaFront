using System.Windows;
using System.Windows.Controls;
using Vote.Statics;

namespace Vote.View
{
    /// <summary>
    ///     Interaction logic for VotePage.xaml
    /// </summary>
    public partial class VotePage : Page
    {
        public VotePage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.VoteViewModel.NavigatedTo();
        }
    }
}