#region Copyright
// <copyright file="IMvxTextProviderBuilder.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Localization;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Localization
{
    public interface IMvxTextProviderBuilder
    {
        MvxJsonDictionaryTextProvider TextProvider { get; }
        void LoadResources(string whichLocalisationFolder);
    }
}