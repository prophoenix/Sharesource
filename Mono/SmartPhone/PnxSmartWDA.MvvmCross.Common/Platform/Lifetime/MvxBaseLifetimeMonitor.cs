#region Copyright
// <copyright file="MvxBaseLifetimeMonitor.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Lifetime;

namespace  PnxSmartWDA.MvvmCross.Platform.Lifetime
{
    public abstract class MvxBaseLifetimeMonitor : IMvxLifetime
    {
        protected void FireLifetimeChange(MvxLifetimeEvent which)
        {
            var handler = LifetimeChanged;
            if (handler != null)
                handler(this, new MvxLifetimeEventArgs(which));
        }

        #region Implementation of IMvxLifetime

        public event EventHandler<MvxLifetimeEventArgs> LifetimeChanged;

        #endregion
    }
}