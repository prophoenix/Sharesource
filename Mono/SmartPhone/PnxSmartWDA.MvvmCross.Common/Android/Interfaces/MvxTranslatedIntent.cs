#region Copyright
// <copyright file="MvxTranslatedIntent.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Views;

namespace  PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public class MvxTranslatedIntent
    {
        #region TranslationResult enum

        public enum TranslationResult
        {
            Request,
            ExistingViewModel
        }

        #endregion

        public MvxTranslatedIntent(MvxShowViewModelRequest showViewModelRequest)
        {
            ShowViewModelRequest = showViewModelRequest;
            Result = TranslationResult.Request;
        }

        public MvxTranslatedIntent(IMvxViewModel existingViewModel)
        {
            ExistingViewModel = existingViewModel;
            Result = TranslationResult.ExistingViewModel;
        }

        public TranslationResult Result { get; private set; }
        public IMvxViewModel ExistingViewModel { get; private set; }
        public MvxShowViewModelRequest ShowViewModelRequest { get; private set; }
    }
}