#region Copyright
// <copyright file="IMvxBindingDescriptionParser.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Generic;

namespace  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders
{
    public interface IMvxBindingDescriptionParser
    {
        IEnumerable<MvxBindingDescription> Parse(string text);
    }
}