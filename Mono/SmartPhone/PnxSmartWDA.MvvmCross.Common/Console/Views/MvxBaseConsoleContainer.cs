using PnxSmartWDA.MvvmCross.Console.Interfaces;
using PnxSmartWDA.MvvmCross.Views;

namespace PnxSmartWDA.MvvmCross.Console.Views
{
    public abstract class MvxBaseConsoleContainer 
        : MvxViewsContainer
          , IMvxConsoleNavigation
    {
        public abstract void Navigate(MvxShowViewModelRequest request);
        public abstract void GoBack();
        public abstract void RemoveBackEntry();
        public abstract bool CanGoBack();
    }
}