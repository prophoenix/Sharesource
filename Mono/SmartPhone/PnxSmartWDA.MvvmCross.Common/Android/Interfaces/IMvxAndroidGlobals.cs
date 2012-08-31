#region Copyright
// <copyright file="IMvxAndroidGlobals.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Reflection;
using Android.Content;

namespace  PnxSmartWDA.MvvmCross.Android.Interfaces
{
    public interface IMvxAndroidGlobals
    {
        string ExecutableNamespace { get; }
        Assembly ExecutableAssembly { get; }
        Context ApplicationContext { get; }
    }
}