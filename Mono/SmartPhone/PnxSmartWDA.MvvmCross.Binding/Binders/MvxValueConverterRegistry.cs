#region Copyright
// <copyright file="MvxValueConverterRegistry.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Generic;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders;
using  PnxSmartWDA.MvvmCross.Interfaces.Converters;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Binding.Binders
{
    public class MvxValueConverterRegistry
        : IMvxValueConverterProvider
        , IMvxValueConverterRegistry
    {
        private readonly Dictionary<string, IMvxValueConverter> _converters = new Dictionary<string, IMvxValueConverter>();

        #region IMvxValueConverterProvider Members

        public IMvxValueConverter Find(string converterName)
        {
            IMvxValueConverter toReturn;
            if (!_converters.TryGetValue(converterName, out toReturn))
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning,"Could not find named converter " + converterName);
            }
            return toReturn;
        }

        #endregion

        #region IMvxValueConverterRegistry Members

        public void AddOrOverwrite(string name, IMvxValueConverter converter)
        {
            _converters[name] = converter;
        }

        #endregion
    }
}