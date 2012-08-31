using System;
using  PnxSmartWDA.MvvmCross.Commands;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Commands;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.ShortNames;
using SmartDevice.Core.Models;

namespace SmartDevice.Core.ViewModels
{
    public class DetailsCustomerViewModel 
        : BaseViewModel
        , IMvxServiceConsumer<IMvxWebBrowserTask>
        , IMvxServiceConsumer<IMvxPhoneCallTask>
    {
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            private set { _customer = value; FirePropertyChanged("Customer"); }
        }

        public DetailsCustomerViewModel(string customerId)
        {
            Customer = DataStore.GetCustomer(customerId);
        }

        public IMvxCommand EditCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                  RequestNavigate<EditCustomerViewModel>(new StringDict()
                                                                                         {
                                                                                            { "customerId", Customer.ID }
                                                                                         });
                                               });
            }
        }

        public IMvxCommand DeleteCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    try
                    {
                        DeleteCustomer();
                        RequestClose(this);
                    }
                    catch (Exception exception)
                    {
#warning TODO - how to send error messages?
                    }
                });
            }
        }

        public IMvxCommand ShowWebsiteCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                   this.GetService<IMvxWebBrowserTask>().ShowWebPage(Customer.Website);
                                               });
            }
        }

        public IMvxCommand CallCustomerCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                   this.GetService<IMvxPhoneCallTask>().MakePhoneCall(Customer.Name, Customer.PrimaryPhone);
                                               });
            }
        }

        public IMvxCommand ShowOnMapCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                   string googleAddress = string.Format("{0} {1}\n{2}, {3}  {4}",
                                                                                        Customer.PrimaryAddress.
                                                                                            Street1,
                                                                                        Customer.PrimaryAddress.
                                                                                            Street2,
                                                                                        Customer.PrimaryAddress.
                                                                                            City,
                                                                                        Customer.PrimaryAddress.
                                                                                            State,
                                                                                        Customer.PrimaryAddress.
                                                                                            Zip);
                                                   googleAddress = Uri.EscapeUriString(googleAddress);

                                                   string url = string.Format("http://maps.google.com/maps?q={0}",
                                                                              googleAddress);
                                                   this.GetService<IMvxWebBrowserTask>().ShowWebPage(url);
                                               });
            }
        }

#warning Broken Code - also should probably use a service to do the save, not the static
        private void DeleteCustomer()
        {
            DataStore.DeleteCustomer(Customer.ID);
        }
    }
}
