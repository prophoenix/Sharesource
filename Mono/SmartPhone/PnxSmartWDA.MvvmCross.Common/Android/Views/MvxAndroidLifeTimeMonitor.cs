#region Copyright
// <copyright file="MvxAndroidLifeTimeMonitor.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.App;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Lifetime;
using  PnxSmartWDA.MvvmCross.Platform.Lifetime;

namespace  PnxSmartWDA.MvvmCross.Android.Views
{
    // For lifetime explained, see http://developer.android.com/guide/topics/fundamentals/activities.html
    // Note that we set Activity = activity in multiple places
    // basically we just want to intercept the activity as early as possible
    // regardless of whether the activity has come from an app switch or a new start or...
    public class MvxAndroidLifetimeMonitor 
        : MvxBaseLifetimeMonitor
        , IMvxAndroidActivityLifetimeListener
        , IMvxAndroidCurrentTopActivity
    {
        private int _createdActivityCount;

        #region IMvxAndroidActivityLifetimeListener Members

        public void OnCreate(Activity activity)
        {
            _createdActivityCount++;
            if (_createdActivityCount == 1)
            {
                FireLifetimeChange(MvxLifetimeEvent.ActivatedFromDisk);
            }
            Activity = activity;
        }

        public void OnStart(Activity activity)
        {
            Activity = activity;
        }

        public void OnRestart(Activity activity)
        {
            Activity = activity;
        }

        public void OnResume(Activity activity)
        {
            Activity = activity;
        }

        public void OnPause(Activity activity)
        {
            // ignored
        }

        public void OnStop(Activity activity)
        {
            // ignored
        }

        public void OnDestroy(Activity activity)
        {
            if (Activity == activity)
                Activity = null;

            _createdActivityCount--;
            if (_createdActivityCount == 0)
            {
                FireLifetimeChange(MvxLifetimeEvent.Closing);
            }
        }

        public void OnViewNewIntent(Activity activity)
        {
            Activity = activity;
        }

        #endregion

        #region IMvxAndroidCurrentTopActivity Members

        public Activity Activity { get; private set; }

        #endregion
    }
}
