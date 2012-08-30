#region Copyright
// <copyright file="IMvxViewModelLoader.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using  PnxSmartWDA.MvvmCross.Views;

namespace  PnxSmartWDA.MvvmCross.Interfaces.ViewModels
{
    public interface IMvxViewModelLoader
    {
        IMvxViewModel LoadViewModel(MvxShowViewModelRequest request);
    }
}