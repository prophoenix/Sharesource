#region Copyright
// <copyright file="IMvxViewDispatcher.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Views;

#endregion

namespace  PnxSmartWDA.MvvmCross.Interfaces.Views
{
    public interface IMvxViewDispatcher : IMvxMainThreadDispatcher
    {
        bool RequestNavigate(MvxShowViewModelRequest request);
        bool RequestClose(IMvxViewModel whichViewModel);
        bool RequestRemoveBackStep();
    }
}