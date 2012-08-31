#region Copyright
// <copyright file="IMvxAndroidActivityLifeTimeListener.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.App;

namespace  PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidActivityLifetimeListener
    {
        void OnCreate(Activity activity);
        void OnStart(Activity activity);
        void OnRestart(Activity activity);
        void OnResume(Activity activity);
        void OnPause(Activity activity);
        void OnStop(Activity activity);
        void OnDestroy(Activity activity);
        void OnViewNewIntent(Activity activity);
    }
}