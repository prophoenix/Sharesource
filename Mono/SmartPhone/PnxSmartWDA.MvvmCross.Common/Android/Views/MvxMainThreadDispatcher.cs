﻿#region Copyright
// <copyright file="MvxMainThreadDispatcher.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using System;
using Android.App;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;
using  PnxSmartWDA.MvvmCross.Platform.Diagnostics;

#endregion

namespace  PnxSmartWDA.MvvmCross.Android.Views
{
    public class MvxMainThreadDispatcher : IMvxMainThreadDispatcher
    {
        private readonly Activity _activity;

        public MvxMainThreadDispatcher(Activity activity)
        {
            _activity = activity;
        }

        #region IMvxMainThreadDispatcher Members

        public bool RequestMainThreadAction(Action action)
        {
            return InvokeOrBeginInvoke(action);
        }

        #endregion

        private bool InvokeOrBeginInvoke(Action action)
        {
            if (_activity == null)
            {
                MvxTrace.Trace("Warning - UI action being ignored - no current activity");
                return false;
            }
            _activity.RunOnUiThread(action);

            return true;
        }
    }
}