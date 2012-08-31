#region Copyright
// <copyright file="IMvxCommand.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;

namespace  PnxSmartWDA.MvvmCross.Interfaces.Commands
{
#if WINDOWS_PHONE
    public interface IMvxCommand : System.Windows.Input.ICommand
    {
        bool CanExecute();
        void Execute();    
    }
#elif NETFX_CORE
    public interface IMvxCommand : System.Windows.Input.ICommand
    {
        bool CanExecute();
        void Execute();
    }
#else
    public interface IMvxCommand
    {
        bool CanExecute(object parameter);
        bool CanExecute();
        void Execute(object parameter);
        void Execute();
        event EventHandler CanExecuteChanged;
    }
#endif
}