#region Copyright
// <copyright file="IMvxViewModelLocatorStore.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Generic;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Application
{
    public interface IMvxViewModelLocatorStore
    {
        void AddLocators(IEnumerable<IMvxViewModelLocator> locators);
        void AddLocator(IMvxViewModelLocator locator);
    }
}