#region Copyright
// <copyright file="MvxEditTextTextTargetBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Reflection;
using Android.Text;
using Android.Widget;
using  PnxSmartWDA.MvvmCross.Binding.Bindings.Target;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Target
{
    public class MvxEditTextTextTargetBinding : MvxPropertyInfoTargetBinding<EditText>
    {        
        public MvxEditTextTextTargetBinding(object target, PropertyInfo targetPropertyInfo) 
            : base(target, targetPropertyInfo)
        {
            var editText = View;
            if (editText == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,"Error - EditText is null in MvxEditTextTextTargetBinding");
            }
            else
            {
                editText.AfterTextChanged += EditTextOnAfterTextChanged;
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get
            {
                return MvxBindingMode.TwoWay;
            }
        }

        private void EditTextOnAfterTextChanged(object sender, AfterTextChangedEventArgs afterTextChangedEventArgs)
        {
            FireValueChanged(View.Text);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var editText = View;
                if (editText != null)
                {
                    editText.AfterTextChanged -= EditTextOnAfterTextChanged;
                }
            }
        }
    }
}