#region Copyright
// <copyright file="MvxPropertyInfoTargetBindingFactory.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Target;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Target.Construction;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Target.Construction
{
    public class MvxPropertyInfoTargetBindingFactory
     : IMvxPluginTargetBindingFactory
    {
        private readonly Func<object, PropertyInfo, IMvxTargetBinding> _bindingCreator;
        private readonly string _targetName;
        private readonly Type _targetType;

        public MvxPropertyInfoTargetBindingFactory(Type targetType, string targetName, Func<object, PropertyInfo, IMvxTargetBinding> bindingCreator)
        {
            _targetType = targetType;
            _targetName = targetName;
            _bindingCreator = bindingCreator;
        }

        protected Type TargetType { get { return _targetType; } }

        #region IMvxPluginTargetBindingFactory Members

        public IEnumerable<MvxTypeAndNamePair> SupportedTypes
        {
            get { return new[] {new MvxTypeAndNamePair() {Name = _targetName, Type = _targetType}}; }
        }

        public IMvxTargetBinding CreateBinding(object target, MvxBindingDescription description)
        {
            var targetPropertyInfo = target.GetType().GetProperty(description.TargetName);
            if (targetPropertyInfo != null)
            {
                try
                {
                    return _bindingCreator(target, targetPropertyInfo);
                }
                catch (ThreadAbortException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    MvxBindingTrace.Trace(
                                            MvxTraceLevel.Error,
"Problem creating target binding for {0} - exception {1}", _targetType.Name, exception.ToString());
                }
            }

            return null;
        }

        #endregion
    }
}