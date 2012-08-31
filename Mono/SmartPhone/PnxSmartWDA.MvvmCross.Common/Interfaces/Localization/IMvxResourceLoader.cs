#region Copyright
// <copyright file="IMvxResourceLoader.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.IO;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Localization
{
    public interface IMvxResourceLoader
    {
        string GetTextResource(string resourcePath);
        void GetResourceStream(string resourcePath, Action<Stream> streamAction);
    }
}