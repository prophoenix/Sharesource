#region Copyright
// <copyright file="MvxValueEventArgs.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Platform
{
    public class MvxValueEventArgs<T>
        : EventArgs
    {
        public MvxValueEventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}