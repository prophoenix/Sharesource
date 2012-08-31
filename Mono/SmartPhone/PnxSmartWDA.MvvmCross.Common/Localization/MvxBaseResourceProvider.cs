#region Copyright
// <copyright file="MvxBaseResourceProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Localization
{
    public abstract class MvxBaseResourceProvider
    {
        protected static string MakeLookupKey(string namespaceKey, string typeKey)
        {
            return string.Format("{0}|{1}", namespaceKey, typeKey);
        }

        protected static string MakeLookupKey(string namespaceKey, string typeKey, string name)
        {
            return string.Format("{0}|{1}|{2}", namespaceKey, typeKey, name);
        }
    }
}