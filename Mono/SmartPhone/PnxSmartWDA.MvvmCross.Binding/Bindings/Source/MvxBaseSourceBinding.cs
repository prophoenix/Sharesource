#region Copyright
// <copyright file="MvxBaseSourceBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Source;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Source
{
    public abstract class MvxBaseSourceBinding 
        : MvxBaseBinding
        , IMvxSourceBinding
    {
        private readonly object _source;

        protected MvxBaseSourceBinding(object source)
        {
            _source = source;
        }

        protected object Source { get { return _source; } }

        #region IMvxSourceBinding Members

        public event EventHandler<MvxSourcePropertyBindingEventArgs> Changed;

        public abstract void SetValue(object value);
        public abstract Type SourceType { get; }
        public abstract bool TryGetValue(out object value);

        #endregion

        protected void FireChanged(MvxSourcePropertyBindingEventArgs args)
        {
            var handler = Changed;
            if (handler != null)
                handler(this, args);
        }
    }
}