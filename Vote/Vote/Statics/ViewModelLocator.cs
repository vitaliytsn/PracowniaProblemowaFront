using GalaSoft.MvvmLight.Ioc;
using Vote.BL;
using Vote.ViewModel;

namespace Vote.Statics
{
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public static SignInPageViewModel SignInViewModel => SimpleIoc.Default.GetInstance<SignInPageViewModel>();
        public static VotePageViewModel VoteViewModel => SimpleIoc.Default.GetInstance<VotePageViewModel>();

        public static void RegisterDependencies()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SignInPageViewModel>();
            SimpleIoc.Default.Register<VotePageViewModel>();


            SimpleIoc.Default.Register<ApiCommunicator>();
        }
    }
}