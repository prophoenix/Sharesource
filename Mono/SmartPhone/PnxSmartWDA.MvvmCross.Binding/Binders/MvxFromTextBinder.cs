#region Copyright
// <copyright file="MvxFromTextBinder.cs" company=" PnxSmartWDA">
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
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;

namespace  PnxSmartWDA.MvvmCross.Binding.Binders
{
    public class MvxFromTextBinder
        : IMvxBinder
        , IMvxServiceConsumer<IMvxBindingDescriptionParser>
    {
        #region IMvxBinder Members

        public IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, string bindingText)
        {
            var bindingDescriptions = this.GetService<IMvxBindingDescriptionParser>().Parse(bindingText);
            if (bindingDescriptions == null)
                return null;

            return Bind(source, target, bindingDescriptions);
        }

        public IEnumerable<IMvxUpdateableBinding> Bind(object source, object target, IEnumerable<MvxBindingDescription> bindingDescriptions)
        {
            return bindingDescriptions.Select(description => BindSingle(new MvxBindingRequest(source, target, description)));
        }

        public IMvxUpdateableBinding BindSingle(MvxBindingRequest bindingRequest)
        {
            return new MvxFullBinding(bindingRequest);
        }

        #endregion
    }
}