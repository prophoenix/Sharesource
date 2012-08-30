using PnxSmartWDA.MvvmCross.ExtensionMethods;
using PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace PnxSmartWDA.MvvmCross.Console.Views
{
    public class MvxConsoleSystemMessageHandler
        : IMvxServiceConsumer<IMvxViewDispatcherProvider>
    {
        public bool ExitFlag { get; set; }

        private IMvxViewDispatcher ViewDispatcher { get { return this.GetService().Dispatcher; } }

        public virtual bool HandleInput(IMvxViewModel viewModel, string input)
        {
            input = input.ToUpper();
            switch (input)
            {
                case "BACK":
                case "B":
                    ViewDispatcher.RequestClose(viewModel);
                    return true;
                case "QUIT":
                case "Q":
                    ExitFlag = true;
                    return true;
            }

            return false;
        }
    }
}