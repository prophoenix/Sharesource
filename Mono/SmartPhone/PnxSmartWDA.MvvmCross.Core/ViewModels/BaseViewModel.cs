using  PnxSmartWDA.MvvmCross.Commands;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Commands;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.ViewModels;
using SmartDevice.Core.Models;

namespace SmartDevice.Core.ViewModels
{
    public class BaseViewModel 
        : MvxViewModel
        , IMvxServiceConsumer<IDataStore>
    {
        protected IDataStore DataStore
        {
            get { return this.GetService<IDataStore>(); }
        }
    }
}