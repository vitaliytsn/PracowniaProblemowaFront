using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Vote.Model.Interfaces;
using Vote.View;

namespace Vote.ViewModel
{
    public class SignInPageViewModel : ViewModelBase
    {
        private readonly INavigationManager _navigationManager;
        private string _login;
        private string _password;

        public SignInPageViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand => new RelayCommand(LogIn);

        public void NavigatedTo()
        {
        }

        private void LogIn()
        {
            MessageBox.Show("Zalogowano z hasłem:" + Password + "login: " + Login);
            _navigationManager.Navigate(typeof(VotePage));
        }
    }
}