using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.ViewModels;
using SmartDevice.Core.ViewModels;

namespace SmartDevice.Core
{
    public class StartApplicationObject 
        : MvxApplicationObject
        , IMvxStartNavigation
    {
        public void Start()
        {
            this.RequestNavigate<CustomerListViewModel>();
        }

        public bool ApplicationCanOpenBookmarks
        {
            get { return false; }
        }
    }
}