#region Copyright
// <copyright file="MvxAndroidViewPresenter.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
using Android.App;
using PnxSmartWDA.MvvmCross.Android.Interfaces;
using PnxSmartWDA.MvvmCross.ExtensionMethods;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;
using PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using PnxSmartWDA.MvvmCross.Interfaces.Views;
using PnxSmartWDA.MvvmCross.Platform.Diagnostics;
using PnxSmartWDA.MvvmCross.Views;

namespace PnxSmartWDA.MvvmCross.Android.Views
{
    public class MvxAndroidViewPresenter
        : IMvxAndroidViewPresenter
          , IMvxServiceConsumer<IMvxAndroidCurrentTopActivity>
          , IMvxServiceConsumer<IMvxAndroidViewModelRequestTranslator>
    {
        private Activity Activity
        {
            get { return this.GetService<IMvxAndroidCurrentTopActivity>().Activity; }
        }

        public void Show(MvxShowViewModelRequest request)
        {
            var requestTranslator = this.GetService<IMvxAndroidViewModelRequestTranslator>();
            var intent = requestTranslator.GetIntentFor(request);
            Activity.StartActivity(intent);
        }

        public void Close(IMvxViewModel toClose)
        {
            toClose.ActOnRegisteredViews(view =>
                                             {
                                                 var activity = view as Activity;
                                                 if (activity != null)
                                                     activity.Finish();
                                             });
        }
    }
}