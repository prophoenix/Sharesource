#region Copyright
// <copyright file="IMvxTargetBindingFactory.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Target.Construction
{
    public interface IMvxTargetBindingFactory
    {
        IMvxTargetBinding CreateBinding(object target, MvxBindingDescription description);
    }
}