#region Copyright
// <copyright file="MvxAndroidViewDispatcherProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace  PnxSmartWDA.MvvmCross.Android.Views
{
    public class MvxAndroidViewDispatcherProvider
        : IMvxViewDispatcherProvider
          , IMvxServiceConsumer<IMvxAndroidCurrentTopActivity>
    {
        private readonly IMvxAndroidViewPresenter _presenter;

        public MvxAndroidViewDispatcherProvider(IMvxAndroidViewPresenter presenter)
        {
            _presenter = presenter;
        }

        public IMvxViewDispatcher Dispatcher
        {
            get { return new MvxAndroidViewDispatcher(this.GetService<IMvxAndroidCurrentTopActivity>().Activity, _presenter); }
        }
    }
}