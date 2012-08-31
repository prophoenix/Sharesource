#region Copyright
// <copyright file="MvxAndroidViewDispatcher.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using Android.App;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;
using  PnxSmartWDA.MvvmCross.Views;

#endregion

namespace  PnxSmartWDA.MvvmCross.Android.Views
{
    public class MvxAndroidViewDispatcher
        : MvxMainThreadDispatcher
        , IMvxViewDispatcher
        , IMvxServiceConsumer<IMvxAndroidViewModelRequestTranslator>
    {
        private readonly Activity _activity;
        private readonly IMvxAndroidViewPresenter _presenter;

        public MvxAndroidViewDispatcher(Activity activity, IMvxAndroidViewPresenter presenter)
            : base(activity)
        {
            _activity = activity;
            _presenter = presenter;
        }

        #region IMvxViewDispatcher Members

        public bool RequestNavigate(MvxShowViewModelRequest request)
        {
            return RequestMainThreadAction(() => _presenter.Show(request));
        }

        public bool RequestClose(IMvxViewModel toClose)
        {
            return RequestMainThreadAction(() => _presenter.Close(toClose));
        }

        public bool RequestRemoveBackStep()
        {
            // not supported on Android? Not sure how to do this currently...
            return false;
        }

        #endregion
    }
}