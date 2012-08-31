#region Copyright
// <copyright file="IMvxViewsContainer.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Views
{
    public interface IMvxViewsContainer
    {
        void Add(Type viewModelType, Type viewType);
        void Add<TViewModel>(Type viewType) where TViewModel : IMvxViewModel;
        bool ContainsKey(Type viewModelType);
        Type GetViewType(Type viewModelType);
    }
}