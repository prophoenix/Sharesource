using System;
using  PnxSmartWDA.MvvmCross.Commands;
using  PnxSmartWDA.MvvmCross.Interfaces.Commands;

namespace SmartDevice.Core.ViewModels
{
    public class EditCustomerViewModel : BaseEditCustomerViewModel
    {
        public EditCustomerViewModel(string customerId)
            : base(customerId)
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
                                                       UpdateCustomer();
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
