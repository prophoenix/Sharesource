using  PnxSmartWDA.MvvmCross.Application;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using SmartDevice.Core.Models;

namespace SmartDevice.Core
{
    public class App 
        : MvxApplication
        , IMvxServiceProducer<IMvxStartNavigation>
        , IMvxServiceProducer<IDataStore>
    {
        public App()
        {
            // set up the model
            var dataStore = new SimpleDataStore();
            this.RegisterServiceInstance<IDataStore>(dataStore);

            // set the start object
            var startApplicationObject = new StartApplicationObject();
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);
        }
    }
}