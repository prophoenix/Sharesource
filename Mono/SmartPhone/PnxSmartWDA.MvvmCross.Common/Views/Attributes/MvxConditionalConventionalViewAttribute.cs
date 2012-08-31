#region Copyright
// <copyright file="MvxConditionalConventionalViewAttribute.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Views.Attributes
{
    public abstract class MvxConditionalConventionalViewAttribute : Attribute
    {
        protected MvxConditionalConventionalViewAttribute()
        {
        }

        public abstract bool IsConventional { get; }
    }
}