#region Copyright
// <copyright file="IMvxValueConverterProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Interfaces.Converters;

namespace  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders
{
    public interface IMvxValueConverterProvider
    {
        IMvxValueConverter Find(string converterName);
    }
}