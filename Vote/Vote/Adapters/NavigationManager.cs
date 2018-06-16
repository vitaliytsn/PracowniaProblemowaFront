using System;
using System.Windows.Controls;
using Vote.Model.Interfaces;

namespace Vote.Adapters
{
    public class NavigationManager : INavigationManager
    {
        private readonly Frame _frame;

        public NavigationManager(Frame frame)
        {
            _frame = frame;
        }

        public void Navigate(Type page)
        {
            _frame.Navigate(Activator.CreateInstance(page));
        }
    }
}