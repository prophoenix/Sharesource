#region Copyright
// <copyright file="MvxPlatformIndependentServiceProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Application;
using  PnxSmartWDA.MvvmCross.Interfaces.IoC;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Platform
{
    public class MvxPlatformIndependentServiceProvider : MvxServiceProvider
    {
        public override void Initialize(IMvxIoCProvider iocProvider)
        {
            base.Initialize(iocProvider);
            SetupPlatfromIndependentServices();
        }

        private void SetupPlatfromIndependentServices()
        {
            RegisterServiceType<IMvxViewModelLoader, MvxViewModelLoader>();
        }
    }
}