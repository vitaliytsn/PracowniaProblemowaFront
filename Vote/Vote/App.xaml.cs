using System.Windows;
using Vote.Statics;

namespace Vote.View
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ViewModelLocator.RegisterDependencies();
        }
    }
}