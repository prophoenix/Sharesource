#region Copyright
// <copyright file="IMvxView.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Views
{
    public interface IMvxView
    {
        bool IsVisible { get; }
    }

    public interface IMvxView<TViewModel>
        : IMvxView
        where TViewModel : class, IMvxViewModel
    {
        TViewModel ViewModel { get; set; }
    }
}