#region Copyright
// <copyright file="MvxIntentResultSink.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;

namespace  PnxSmartWDA.MvvmCross.Android.Platform
{
    public class MvxIntentResultSink : IMvxIntentResultSink, IMvxIntentResultSource
    {
        #region Implementation of IMvxIntentResultSink

        public void OnResult(MvxIntentResultEventArgs result)
        {
            var handler = Result;
            if (handler != null)
                handler(this, result);
        }

        #endregion

        #region Implementation of IMvxIntentResultSource

        public event EventHandler<MvxIntentResultEventArgs> Result;

        #endregion
    }
}