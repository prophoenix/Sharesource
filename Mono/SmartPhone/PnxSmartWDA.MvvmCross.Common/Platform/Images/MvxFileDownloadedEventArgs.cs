#region Copyright
// <copyright file="MvxFileDownloadedEventArgs.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Platform.Images
{
    public class MvxFileDownloadedEventArgs
        : EventArgs
    {
        public MvxFileDownloadedEventArgs(string url, string downloadPath)
        {
            DownloadPath = downloadPath;
            Url = url;
        }

        public string Url { get; private set; }
        public string DownloadPath { get; private set; }
    }
}