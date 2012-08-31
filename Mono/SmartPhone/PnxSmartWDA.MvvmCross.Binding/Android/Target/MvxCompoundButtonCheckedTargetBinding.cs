#region Copyright
// <copyright file="MvxCompoundButtonCheckedTargetBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Reflection;
using Android.Widget;
using  PnxSmartWDA.MvvmCross.Binding.Bindings.Target;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Target
{
    public class MvxCompoundButtonCheckedTargetBinding 
        : MvxPropertyInfoTargetBinding<CompoundButton>
    {
        public MvxCompoundButtonCheckedTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var compoundButton = View;
            if (compoundButton == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,
                                      "Error - compoundButton is null in MvxCompoundButtonCheckedTargetBinding");
            }
            else
            {
                compoundButton.CheckedChange += CompoundButtonOnCheckedChange;
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        private void CompoundButtonOnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs args)
        {
            FireValueChanged(View.Checked);
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var compoundButton = View;
                if (compoundButton != null)
                {
                    compoundButton.CheckedChange -= CompoundButtonOnCheckedChange;
                }
            }
        }
    }
}