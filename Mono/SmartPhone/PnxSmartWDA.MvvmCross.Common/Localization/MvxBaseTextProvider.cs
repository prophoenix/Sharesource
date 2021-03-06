#region Copyright
// <copyright file="MvxBaseTextProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Interfaces.Localization;

namespace  PnxSmartWDA.MvvmCross.Localization
{
    public abstract class MvxBaseTextProvider :
        MvxBaseResourceProvider, IMvxTextProvider
    {
        #region Implementation of IMvxTextProvider

        public abstract string GetText(string namespaceKey, string typeKey, string name);

        public string GetText(string namespaceKey, string typeKey, string name, params object[] formatArgs)
        {
            var baseText = GetText(namespaceKey, typeKey, name);
            if (string.IsNullOrEmpty(baseText))
                return baseText;
            return string.Format(baseText, formatArgs);
        }

        #endregion
    }
}