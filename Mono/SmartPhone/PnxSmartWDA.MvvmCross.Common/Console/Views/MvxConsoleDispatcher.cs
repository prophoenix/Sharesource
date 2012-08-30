#region Copyright
// <copyright file="MvxConsoleDispatcher.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion
#region using

using System;
using PnxSmartWDA.MvvmCross.Console.Interfaces;
using PnxSmartWDA.MvvmCross.ExtensionMethods;
using PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using PnxSmartWDA.MvvmCross.Interfaces.Views;
using PnxSmartWDA.MvvmCross.Views;

#endregion

namespace PnxSmartWDA.MvvmCross.Console.Views
{
    public class MvxConsoleDispatcher 
        : IMvxViewDispatcher
        , IMvxServiceConsumer<IMvxConsoleNavigation>
    {
        #region IMvxViewDispatcher Members

        public bool RequestMainThreadAction(Action action)
        {
            return InvokeOrBeginInvoke(action);
        }

        public bool RequestNavigate(MvxShowViewModelRequest request)
        {
            var navigation = this.GetService<IMvxConsoleNavigation>();
            return InvokeOrBeginInvoke(() => navigation.Navigate(request));
        }

        public bool RequestClose(IMvxViewModel toClose)
        {
            var navigation = this.GetService<IMvxConsoleNavigation>();
            return InvokeOrBeginInvoke(navigation.GoBack);
        }

        public bool RequestRemoveBackStep()
        {
            var navigation = this.GetService<IMvxConsoleNavigation>();
            return InvokeOrBeginInvoke(navigation.RemoveBackEntry);
        }

        #endregion

        private bool InvokeOrBeginInvoke(Action action)
        {
            action();
            return true;
        }
    }
}