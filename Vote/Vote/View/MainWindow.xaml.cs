using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using Vote.Adapters;
using Vote.Model.Interfaces;
using Vote.Statics;

namespace Vote.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private INavigationManager _navigationManager;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _navigationManager = new NavigationManager(RootView);
            SimpleIoc.Default.Register(() => _navigationManager);

            ViewModelLocator.MainViewModel.NavigatedTo();
        }
    }
}