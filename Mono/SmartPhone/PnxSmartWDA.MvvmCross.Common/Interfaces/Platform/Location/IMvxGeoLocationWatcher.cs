#region Copyright
// <copyright file="IMvxGeoLocationWatcher.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Platform.Location
{
    public interface IMvxGeoLocationWatcher
    {
        void Start(MvxGeoLocationOptions options, Action<MvxGeoLocation> success, Action<MvxLocationError> error);
        void Stop();
    }
}