#region Copyright
// <copyright file="MvxSimpleBindingActivity.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Binding.Android.Views;
using  PnxSmartWDA.MvvmCross.ViewModels;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Simple
{
    public class MvxSimpleBindingActivity 
        : MvxBindingActivityView<MvxNullViewModel>
    {
        public new object ViewModel { get; set; }

        public override object DefaultBindingSource
        {
            get { return ViewModel; }
        }

        protected sealed override void OnViewModelSet()
        {
            // ignored  here
        }
    }

    public class MvxSimpleBindingActivity<TViewModel>
        : MvxBindingActivityView<MvxNullViewModel>
    {
        public new TViewModel ViewModel { get; set; }

        public override object DefaultBindingSource
        {
            get { return ViewModel; }
        }

        protected sealed override void OnViewModelSet()
        {
            // ignored  here
        }
    }
}