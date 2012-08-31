#region Copyright
// <copyright file="IMvxViewModelLocator.cs" company=" PnxSmartWDA">
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

namespace  PnxSmartWDA.MvvmCross.Interfaces.ViewModels
{
    public interface IMvxViewModelLocator
    {
        bool TryLoad(Type viewModelType, IDictionary<string, string> parameters, out IMvxViewModel model);
    }
}