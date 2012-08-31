#region Copyright
// <copyright file="IMvxMainThreadDispatcher.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using System;

#endregion

namespace  PnxSmartWDA.MvvmCross.Interfaces.Views
{
    public interface IMvxMainThreadDispatcher
    {
        bool RequestMainThreadAction(Action action);
    }
}