#region Copyright
// <copyright file="IMvxFileDownloadCache.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Platform.Images
{
    public interface IMvxFileDownloadCache
    {
        void RequestLocalFilePath(string httpSource, Action<string> success, Action<Exception> error);
    }
}