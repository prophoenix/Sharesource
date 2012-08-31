#region Copyright
// <copyright file="MvxAutoCompleteTextViewPartialTextTargetBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Reflection;
using  PnxSmartWDA.MvvmCross.Binding.Android.Views;
using  PnxSmartWDA.MvvmCross.Binding.Bindings.Target;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Target
{
    public class MvxAutoCompleteTextViewPartialTextTargetBinding : MvxPropertyInfoTargetBinding<MvxBindableAutoCompleteTextView>
    {
#warning Cut and paste could be reduced for these controls - could also consider using attributes!
        public MvxAutoCompleteTextViewPartialTextTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var autoComplete = View;
            if (autoComplete == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in MvxAutoCompleteTextViewPartialTextTargetBinding");
            }
            else
            {
                autoComplete.PartialTextChanged += AutoCompleteOnPartialTextChanged;
            }
        }

        private void AutoCompleteOnPartialTextChanged(object sender, EventArgs eventArgs)
        {
            FireValueChanged(View.PartialText);
        }

        public override MvxBindingMode DefaultMode
        {
            get
            {
                return MvxBindingMode.OneWayToSource;
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var autoComplete = View;
                if (autoComplete != null)
                {
                    autoComplete.PartialTextChanged -= AutoCompleteOnPartialTextChanged;
                }
            }
        }
    }
}