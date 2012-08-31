#region Copyright
// <copyright file="MvxOpenNetCfServiceProviderSetup.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Platform;

namespace  PnxSmartWDA.MvvmCross.IoC
{
    public static class MvxOpenNetCfServiceProviderSetup
    {
        public static void Initialize()
        {
            var ioc = new MvxOpenNetCfIocProvider();
            MvxServiceProviderSetup.Initialize(ioc);
        }

        public static void Initialize(Type serviceProviderType)
        {
            var ioc = new MvxOpenNetCfIocProvider();
            MvxServiceProviderSetup.Initialize(serviceProviderType, ioc);
        }
    }
}