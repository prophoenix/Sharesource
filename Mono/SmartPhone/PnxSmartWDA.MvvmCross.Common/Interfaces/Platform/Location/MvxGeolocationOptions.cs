#region Copyright
// <copyright file="MvxGeolocationOptions.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Interfaces.Platform.Location
{
    public class MvxGeoLocationOptions
    {
        public int Timeout { get; set; }
        public int MaximumAge { get; set; }
        public bool EnableHighAccuracy { get; set; }
    }
}
