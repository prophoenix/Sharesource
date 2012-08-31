#region Copyright
// <copyright file="MvxServiceProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Core;
using  PnxSmartWDA.MvvmCross.Exceptions;
using  PnxSmartWDA.MvvmCross.Interfaces.IoC;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;

namespace  PnxSmartWDA.MvvmCross.Platform
{
    public class MvxServiceProvider : MvxSingleton<IMvxServiceProviderSetup>, IMvxServiceProviderSetup
    {
        private IMvxIoCProvider _ioc;

        #region IMvxServiceProviderSetup Members

        public virtual void Initialize(IMvxIoCProvider iocProvider)
        {
            if (_ioc != null)
                throw new MvxException("IoC provider already set");

            _ioc = iocProvider;
        }

        public virtual bool SupportsService<T>() where T : class
        {
#if DEBUG
            if (_ioc == null)
                throw new MvxException("IoC provider not set");
#endif
            return _ioc.SupportsService<T>();
        }

        public virtual T GetService<T>() where T : class
        {
#if DEBUG
            if (_ioc == null)
                throw new MvxException("IoC provider not set");
#endif
            return _ioc.GetService<T>();
        }

        public bool TryGetService<T>(out T service) where T : class
        {
#if DEBUG
            if (_ioc == null)
                throw new MvxException("IoC provider not set");
#endif
            return _ioc.TryGetService<T>(out service);
        }

        public virtual void RegisterServiceType<TFrom, TTo>()
        {
#if DEBUG
            if (_ioc == null)
                throw new MvxException("IoC provider not set");
#endif
            _ioc.RegisterServiceType<TFrom, TTo>();
        }

        public virtual void RegisterServiceInstance<TInterface>(TInterface theObject)
        {
#if DEBUG
            if (_ioc == null)
                throw new MvxException("IoC provider not set");
#endif
            _ioc.RegisterServiceInstance(theObject);
        }

        #endregion
    }
}