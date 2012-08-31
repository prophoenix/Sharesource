#region Copyright
// <copyright file="MvxOpenNetCfDependencyAttribute.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region Credit - OpenNetCf

// This file is based on the OpenNetCf IoC container - used under free license -see http://ioc.codeplex.com

#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.IoC
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MvxOpenNetCfDependencyAttribute : Attribute
    {
    }
}