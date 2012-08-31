using System;
using  PnxSmartWDA.MvvmCross.Commands;
using  PnxSmartWDA.MvvmCross.Interfaces.Commands;

namespace SmartDevice.Core.ViewModels
{
    public class NewCustomerViewModel
        : BaseEditCustomerViewModel
    {
        public NewCustomerViewModel()
            : base(null)
        {            
        }

        public override IMvxCommand SaveCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                   try
                                                   {
                                                       AddNewCustomer();
                                                       RequestClose(this);
                                                   }
                                                   catch (Exception exception)
                                                   {
#warning TODO - how to send error messages?
                                                   }
                                               });
            }
        }
    }
}
