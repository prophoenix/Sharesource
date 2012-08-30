#region Copyright
// <copyright file="MvxAndroidServiceProvider.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
#region using

using Android.Content;
using PnxSmartWDA.MvvmCross.Android.Interfaces;
using PnxSmartWDA.MvvmCross.Android.Platform.Location;
using PnxSmartWDA.MvvmCross.Android.Platform.Tasks;
using PnxSmartWDA.MvvmCross.Android.Views;
using PnxSmartWDA.MvvmCross.Interfaces.IoC;
using PnxSmartWDA.MvvmCross.Interfaces.Localization;
using PnxSmartWDA.MvvmCross.Interfaces.Platform;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Lifetime;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Location;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;
using PnxSmartWDA.MvvmCross.Platform;

#endregion

namespace PnxSmartWDA.MvvmCross.Android.Platform
{
    [MvxServiceProvider]
    public class MvxAndroidServiceProvider : MvxPlatformIndependentServiceProvider
    {
        public static new MvxAndroidServiceProvider Instance
        {
            get { return (MvxAndroidServiceProvider)MvxPlatformIndependentServiceProvider.Instance; }
        }

        public override void Initialize(IMvxIoCProvider iocProvider)
        {
            base.Initialize(iocProvider);
            RegisterPlatformTypes();
        }

        private void RegisterPlatformTypes()
        {
            RegisterServiceInstance<IMvxTrace>(new MvxDebugTrace());
            RegisterServiceType<IMvxWebBrowserTask, MvxWebBrowserTask>();
            RegisterServiceType<IMvxPhoneCallTask, MvxPhoneCallTask>();
            RegisterServiceType<IMvxShareTask, MvxShareTask>();
            RegisterServiceType<IMvxComposeEmailTask, MvxComposeEmailTask>();
   
            var lifetimeMonitor = new MvxAndroidLifetimeMonitor();
            RegisterServiceInstance<IMvxAndroidActivityLifetimeListener>(lifetimeMonitor);
            RegisterServiceInstance<IMvxAndroidCurrentTopActivity>(lifetimeMonitor);
            RegisterServiceInstance<IMvxLifetime>(lifetimeMonitor);
        }

        public void RegisterPlatformContextTypes(Context applicationContext)
        {
            RegisterServiceInstance<IMvxResourceLoader>(new MvxAndroidResourceLoader());
            RegisterServiceInstance<IMvxSimpleFileStoreService>(new MvxAndroidFileStoreService());

            RegisterServiceType<IMvxPictureChooserTask, MvxPictureChooserTask>();

#warning Would be nice if sound effects were optional so that not everyone has to link to xna!
#warning TODO - sound effects!
            //var soundEffectLoader = new SoundEffects.MvxSoundEffectObjectLoader();
            //RegisterServiceInstance<IMvxResourceObjectLoaderConfiguration<IMvxSoundEffect>>(soundEffectLoader);
            //RegisterServiceInstance<IMvxResourceObjectLoader<IMvxSoundEffect>>(soundEffectLoader);

#warning Would be very nice if GPS were optional!
            RegisterServiceInstance<IMvxGeoLocationWatcher>(new MvxAndroidGeoLocationWatcher());
        }
    }
}