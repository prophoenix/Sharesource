#region Copyright
// <copyright file="MvxPropertyInfoSourceBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Threading;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Source;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Source
{
    public class MvxPropertyInfoSourceBinding : MvxBasePropertyInfoSourceBinding
    {
        public MvxPropertyInfoSourceBinding(object source, string propertyName)
            : base(source, propertyName)
        {
        }

        public override Type SourceType
        {
            get { return (PropertyInfo == null) ? null : PropertyInfo.PropertyType; }
        }

        protected override void OnBoundPropertyChanged()
        {
            FireChanged(new MvxSourcePropertyBindingEventArgs(this));
        }

        public override bool TryGetValue(out object value)
        {
            if (PropertyInfo == null)
            {
                value = null;
                return false;
            }

            if (!PropertyInfo.CanRead)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,"SetValue ignored in binding - target property is writeonly");
                value = null;
                return false;
            }

            value = PropertyInfo.GetValue(Source, null);
            return true;
        }

        public override void SetValue(object value)
        {
            if (PropertyInfo == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,"SetValue ignored in binding - target property missing");
                return;
            }

            if (!PropertyInfo.CanWrite)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning, "SetValue ignored in binding - target property is readonly");
                return;
            }

            try
            {
                if (PropertyInfo.PropertyType.IsGenericType && PropertyInfo.PropertyType.IsValueType)
                {
                    var underlyingType = Nullable.GetUnderlyingType(PropertyInfo.PropertyType);
                    var converted = Convert.ChangeType(value, underlyingType);
                    PropertyInfo.SetValue(Source, converted, null);
                }
                else
                {
                    var converted = Convert.ChangeType(value, PropertyInfo.PropertyType);
                    PropertyInfo.SetValue(Source, converted, null);
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception exception)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "SetValue failed with exception - " + exception.ToLongString());
            }
        }
    }
}