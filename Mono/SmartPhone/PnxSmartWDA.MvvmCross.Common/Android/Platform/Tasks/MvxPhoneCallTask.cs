#region Copyright
// <copyright file="MvxPhoneCallTask.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.Content;
using Android.Net;
using Android.Telephony;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks;

namespace  PnxSmartWDA.MvvmCross.Android.Platform.Tasks
{
    public class MvxPhoneCallTask : MvxAndroidTask, IMvxPhoneCallTask
    {
        #region IMvxPhoneCallTask Members

        public void MakePhoneCall(string name, string number)
        {
#warning What exceptions could be thrown here?
#warning Does this need to be on UI thread?
            var phoneNumber = PhoneNumberUtils.FormatNumber(number);
            var newIntent = new Intent(Intent.ActionDial, Uri.Parse("tel:" + phoneNumber));
            StartActivity(newIntent);
        }

        #endregion
    }
}