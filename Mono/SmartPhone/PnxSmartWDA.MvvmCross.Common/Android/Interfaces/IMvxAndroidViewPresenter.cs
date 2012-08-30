#region Copyright
// <copyright file="IMvxAndroidViewPresenter.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using PnxSmartWDA.MvvmCross.Views;

namespace PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidViewPresenter
    {
        void Show(MvxShowViewModelRequest request);
        void Close(IMvxViewModel viewModel);
    }
}