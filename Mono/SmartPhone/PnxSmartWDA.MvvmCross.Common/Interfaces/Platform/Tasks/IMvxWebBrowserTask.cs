#region Copyright
// <copyright file="IMvxWebBrowserTask.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

#endregion

namespace  PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks
{
    public interface IMvxWebBrowserTask
    {
        void ShowWebPage(string url);
    }
}