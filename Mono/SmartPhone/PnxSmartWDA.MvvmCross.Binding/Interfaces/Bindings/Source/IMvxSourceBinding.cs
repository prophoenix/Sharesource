#region Copyright
// <copyright file="IMvxSourceBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Source
{
    public interface IMvxSourceBinding : IMvxBinding 
    {
        Type SourceType { get; }
        void SetValue(object value);
        event EventHandler<MvxSourcePropertyBindingEventArgs> Changed;
        bool TryGetValue(out object value);
    }
}