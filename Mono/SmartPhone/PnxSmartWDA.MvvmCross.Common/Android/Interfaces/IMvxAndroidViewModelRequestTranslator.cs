#region Copyright
// <copyright file="IMvxAndroidViewModelRequestTranslator.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using Android.Content;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Views;

namespace  PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidViewModelLoader
    {
        IMvxViewModel Load(Intent intent);
    }

    public interface IMvxAndroidViewModelRequestTranslator
    {
        Intent GetIntentFor(MvxShowViewModelRequest request);

        // Important: if calling GetIntentWithKeyFor then you must later call RemoveSubViewModelWithKey on the returned key
        Tuple<Intent, int> GetIntentWithKeyFor(IMvxViewModel existingViewModelToUse);
        void RemoveSubViewModelWithKey(int key);
    }
}