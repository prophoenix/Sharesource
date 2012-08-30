#region Copyright
// <copyright file="MvxConsoleServiceProvider.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
#region using

using PnxSmartWDA.MvvmCross.Console.Services.Tasks;
using PnxSmartWDA.MvvmCross.Interfaces.IoC;
using PnxSmartWDA.MvvmCross.Interfaces.Localization;
using PnxSmartWDA.MvvmCross.Interfaces.Platform;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;
using PnxSmartWDA.MvvmCross.Platform;

#endregion

namespace PnxSmartWDA.MvvmCross.Console.Services
{
    [MvxServiceProvider]
    public class MvxConsoleServiceProvider : MvxPlatformIndependentServiceProvider
    {
        public override void Initialize(IMvxIoCProvider iocProvider)
        {
            base.Initialize(iocProvider);
            SetupPlatformTypes();
        }

        private void SetupPlatformTypes()
        {
            RegisterServiceInstance<IMvxTrace>(new MvxDebugTrace());
            RegisterServiceInstance<IMvxResourceLoader>(new MvxConsoleResourceLoader());
            RegisterServiceType<IMvxSimpleFileStoreService, MvxFileStoreService>();
            RegisterServiceType<IMvxWebBrowserTask, MvxWebBrowserTask>();
            RegisterServiceType<IMvxPhoneCallTask, MvxPhoneCallTask>();
        }
    }
}