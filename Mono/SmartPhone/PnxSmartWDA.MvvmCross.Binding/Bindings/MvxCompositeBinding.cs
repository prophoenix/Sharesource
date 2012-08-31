#region Copyright
// <copyright file="MvxCompositeBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Generic;
using System.Linq;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings
{
    public class MvxCompositeBinding : MvxBaseBinding
    {
        private readonly List<IMvxBinding> _bindings;

        public MvxCompositeBinding(params IMvxBinding[] args)
        {
            _bindings = args.ToList();
        }

        public void Add(params IMvxBinding[] args)
        {
            _bindings.AddRange(args);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _bindings.ForEach(x => x.Dispose());
                _bindings.Clear();
            }
            base.Dispose(isDisposing);
        }
    }
}