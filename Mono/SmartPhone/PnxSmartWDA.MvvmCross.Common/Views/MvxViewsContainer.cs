#region Copyright
// <copyright file="MvxViewsContainer.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Collections.Generic;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace  PnxSmartWDA.MvvmCross.Views
{
    public abstract class MvxViewsContainer
        : IMvxViewsContainer
    {
        private readonly Dictionary<Type, Type> _bindingMap = new Dictionary<Type, Type>();

        #region IMvxViewsContainer Members

        public void Add(Type viewModelType, Type viewType)
        {
            _bindingMap[viewModelType] = viewType;
        }

        public void Add<TViewModel>(Type viewType) where TViewModel : IMvxViewModel
        {
            Add(typeof (TViewModel), viewType);
        }

        public bool ContainsKey(Type viewModelType)
        {
            return _bindingMap.ContainsKey(viewModelType);
        }

        public Type GetViewType(Type viewModelType)
        {
            Type binding;
            if (!_bindingMap.TryGetValue(viewModelType, out binding))
                throw new KeyNotFoundException("Could not find view for " + viewModelType);

            return binding;
        }

        #endregion
    }
}