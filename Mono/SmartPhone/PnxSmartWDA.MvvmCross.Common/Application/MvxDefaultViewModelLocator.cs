#region Copyright
// <copyright file="MvxDefaultViewModelLocator.cs" company=" PnxSmartWDA">
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
using System.Linq;
using System.Reflection;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Application
{
    public class MvxDefaultViewModelLocator
        : IMvxViewModelLocator
    {
        #region IMvxViewModelLocator Members

        public bool TryLoad(Type viewModelType, IDictionary<string, string> parameters, out IMvxViewModel model)
        {
            model = null;
            var constructor = viewModelType
#if NETFX_CORE
                .GetTypeInfo().DeclaredConstructors
#else
                .GetConstructors()
#endif
                .FirstOrDefault(c => c.GetParameters().All(p=> p.ParameterType == typeof(string)));

            if (constructor == null)
                return false;

            var invokeWith = new List<object>();
            foreach (var parameter in constructor.GetParameters())
            {
                string parameterValue = null;
                if (parameters == null ||
                    !parameters.TryGetValue(parameter.Name, out parameterValue))
                {
                    MvxTrace.Trace("Missing parameter in call to {0} - missing parameter {1} - asssuming null", viewModelType,
                                   parameter.Name);
                }
                invokeWith.Add(parameterValue);
            }

            model = Activator.CreateInstance(viewModelType, invokeWith.ToArray()) as IMvxViewModel;
            return (model != null);
        }

        #endregion
    }
}