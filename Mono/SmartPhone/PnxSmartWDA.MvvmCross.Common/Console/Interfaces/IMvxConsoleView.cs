#region Copyright
// <copyright file="IMvxConsoleView.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Author - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace PnxSmartWDA.MvvmCross.Console.Interfaces
{
    public interface IMvxConsoleView : IMvxView
    {
        void HackSetViewModel(object viewModel);
        bool HandleInput(string input);
    }
}