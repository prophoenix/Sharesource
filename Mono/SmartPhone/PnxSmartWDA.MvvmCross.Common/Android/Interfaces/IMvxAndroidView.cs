#region Copyright
// <copyright file="IMvxAndroidView.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using Android.Content;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace  PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidView
        : IMvxView
    {
        void MvxInternalStartActivityForResult(Intent intent, int requestCode);
    }

    public interface IMvxAndroidView<TViewModel>
        : IMvxView<TViewModel>
        , IMvxAndroidView
        , IMvxServiceConsumer<IMvxAndroidViewModelLoader>
        , IMvxServiceConsumer<IMvxAndroidViewModelRequestTranslator>
        , IMvxServiceConsumer<IMvxAndroidActivityLifetimeListener>
        where TViewModel : class, IMvxViewModel
    {
        new TViewModel ViewModel { get; set; }
    }
}