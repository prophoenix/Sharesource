#region Copyright
// <copyright file="MvxNullTargetBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Target
{
    public class MvxNullTargetBinding : MvxBaseTargetBinding
    {
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneTime; }
        }

        public override Type TargetType
        {
            get { return typeof(Object); }
        }

        public override void SetValue(object value)
        {
            // ignored
        }
    }
}