#region Copyright
// <copyright file="MvxBaseBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings
{
    public abstract class MvxBaseBinding  : IMvxBinding
    {
        ~MvxBaseBinding()
        {
            Dispose(false);
        }

        #region IMvxBinding Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        protected virtual void Dispose(bool isDisposing)
        {
            // nothing to do in this base class
        }
    }
}