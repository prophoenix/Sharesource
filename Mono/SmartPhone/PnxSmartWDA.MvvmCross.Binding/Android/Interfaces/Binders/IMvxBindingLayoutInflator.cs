#region Copyright
// <copyright file="IMvxBindingLayoutInflator.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using Android.Views;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Interfaces.Binders
{
    public interface IMvxBindingLayoutInflator : IDisposable
    {
        View Inflate(int resource, ViewGroup id);
    }
}