#region Copyright
// <copyright file="IMvxViewModelLocatorAnalyser.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace  PnxSmartWDA.MvvmCross.Interfaces.ViewModels
{
    public interface IMvxViewModelLocatorAnalyser
    {
        IEnumerable<MethodInfo> GenerateLocatorMethods(Type locatorType);
    }
}