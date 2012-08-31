#region Copyright
// <copyright file="MvxGeoLocation.cs" company=" PnxSmartWDA">
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
    public class MvxGeoLocation
    {
        public MvxGeoLocation()
        {
            Coordinates = new MvxCoordinates();
        }

        public MvxCoordinates Coordinates { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}