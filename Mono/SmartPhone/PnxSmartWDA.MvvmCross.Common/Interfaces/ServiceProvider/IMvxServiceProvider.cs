#region Copyright
// <copyright file="IMvxServiceProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider
{
    public interface IMvxServiceProvider
    {
        bool SupportsService<T>() where T : class;
        T GetService<T>() where T : class;
        bool TryGetService<T>(out T service) where T : class;
    }
}