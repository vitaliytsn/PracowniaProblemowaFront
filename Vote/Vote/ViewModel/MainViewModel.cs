using GalaSoft.MvvmLight;
using Vote.Model.Interfaces;
using Vote.View;

namespace Vote.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationManager _navigationManager;

        public MainViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void NavigatedTo()
        {
            _navigationManager.Navigate(typeof(VotePage));
        }
    }
}