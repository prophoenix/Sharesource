#region Copyright
// <copyright file="MvxBaseSplashScreenActivity.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Threading;
using Android.OS;
using Android.Views;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.Android.Platform;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Platform;
using  PnxSmartWDA.MvvmCross.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Android.Views
{
    public abstract class MvxBaseSplashScreenActivity
        : MvxActivityView<MvxNullViewModel>
        , IMvxAndroidSplashScreenActivity
        , IMvxServiceConsumer<IMvxStartNavigation>
    {
        private const int NoContent = 0;

        private static bool _primaryInitialized = false;
        private static MvxBaseAndroidSetup _setup;

        private readonly int _resourceId;

        protected MvxBaseSplashScreenActivity(int resourceId = NoContent)
        {
            _resourceId = resourceId;
        }

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            _setup = MvxAndroidSetupSingleton.GetOrCreateSetup(ApplicationContext);

            if (!_primaryInitialized)
            {
                _primaryInitialized = true;

                // initialize app if necessary
                if (_setup.State == MvxBaseSetup.MvxSetupState.Uninitialized)
                {
                    _setup.InitializePrimary();
                }
            }

            base.OnCreate(bundle);

            if (_resourceId != NoContent)
            {
                // Set our view from the "splash" layout resource
                SetContentView(_resourceId);
            }
        }

        protected override void OnViewModelSet()
        {
            // ignored
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (_setup.State == MvxBaseSetup.MvxSetupState.Initialized)
            {
                TriggerFirstNavigate();
            }
            else
            {
                ThreadPool.QueueUserWorkItem((ignored) =>
                {
                    _setup.InitializeSecondary();
                    TriggerFirstNavigate();
                });
            }
        }

        private void TriggerFirstNavigate()
        {
            var starter = this.GetService<IMvxStartNavigation>();
            starter.Start();
        }
    }
}