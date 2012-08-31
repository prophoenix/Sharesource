#region Copyright
// <copyright file="IMvxResourceObjectLoader.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Interfaces.Localization
{
    public interface IMvxResourceObjectLoader<T>
        where T : IMvxResourceObject
    {
        T Load(string namespaceKey, string typeKey, string entryKey);
    }
}