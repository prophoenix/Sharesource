#region Copyright
// <copyright file="MvxShareTask.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.Exceptions;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Platform.Diagnostics;
using Uri = Android.Net.Uri;

namespace  PnxSmartWDA.MvvmCross.Android.Platform.Tasks
{
    public class MvxShareTask 
        : MvxAndroidTask
        , IMvxShareTask
    {
        public void ShareShort(string message)
        {
            var shareIntent = new Intent(global::Android.Content.Intent.ActionSend);
            shareIntent.PutExtra(global::Android.Content.Intent.ExtraText, message ?? string.Empty);
            shareIntent.SetType("text/plain");
            StartActivity(shareIntent);
        }

        public void ShareLink(string title, string message, string link)
        {
            var shareIntent = new Intent(global::Android.Content.Intent.ActionSend);

            shareIntent.PutExtra(global::Android.Content.Intent.ExtraSubject, title ?? string.Empty);
            shareIntent.PutExtra(global::Android.Content.Intent.ExtraText, message + " " + link);
            shareIntent.SetType("text/plain");

            StartActivity(shareIntent);
        }
    }
}