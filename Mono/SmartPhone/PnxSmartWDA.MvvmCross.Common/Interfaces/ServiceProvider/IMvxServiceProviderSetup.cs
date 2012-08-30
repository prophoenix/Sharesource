#region Copyright
// <copyright file="IMvxServiceProviderSetup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using  PnxSmartWDA.MvvmCross.Interfaces.IoC;

namespace  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider
{
    public interface IMvxServiceProviderSetup : IMvxServiceProviderRegistry
    {
        void Initialize(IMvxIoCProvider iocProvider);
    }
}