#region Copyright
// <copyright file="MvxDirectToSourceBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Source
{
    public class MvxDirectToSourceBinding : MvxBaseSourceBinding
    {
        public MvxDirectToSourceBinding(object source) 
            : base(source)
        {

        }

        public override Type SourceType
        {
            get
            {
                return Source == null ? typeof (object) : Source.GetType(); }
        }

        public override void SetValue(object value)
        {
            MvxBindingTrace.Trace(MvxTraceLevel.Warning,
                                  "ToSource binding is not available for direct pathed source bindings");
        }

        public override bool TryGetValue(out object value)
        {
            value = Source;
            return true;
        }
    }
}