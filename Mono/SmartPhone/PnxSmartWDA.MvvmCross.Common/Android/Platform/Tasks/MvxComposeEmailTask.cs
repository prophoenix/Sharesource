#region Copyright
// <copyright file="MvxComposeEmailTask.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Provider;
using PnxSmartWDA.MvvmCross.Android.Interfaces;
using PnxSmartWDA.MvvmCross.Exceptions;
using PnxSmartWDA.MvvmCross.ExtensionMethods;
using PnxSmartWDA.MvvmCross.Interfaces.Platform;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;
using PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using PnxSmartWDA.MvvmCross.Platform.Diagnostics;
using Uri = Android.Net.Uri;

namespace PnxSmartWDA.MvvmCross.Android.Platform.Tasks
{
    public class MvxComposeEmailTask 
        : MvxAndroidTask
        , IMvxComposeEmailTask
    {
        public void ComposeEmail(string to, string cc, string subject, string body, bool isHtml)
        {
            var emailIntent = new Intent(global::Android.Content.Intent.ActionSend);

            var toList = new [] { to ?? string.Empty };
            var ccList = new [] { cc ?? string.Empty };;

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraEmail, toList);
            emailIntent.PutExtra(global::Android.Content.Intent.ExtraCc, ccList);

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraSubject, subject ?? string.Empty);

            if (isHtml)
                emailIntent.SetType("text/html");
            else
                emailIntent.SetType("plain/text");

            emailIntent.PutExtra(global::Android.Content.Intent.ExtraText, body ?? string.Empty);

            StartActivity(emailIntent);
        }
    }
}