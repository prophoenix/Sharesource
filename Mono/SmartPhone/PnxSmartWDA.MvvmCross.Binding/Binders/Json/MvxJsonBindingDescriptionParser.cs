#region Copyright
// <copyright file="MvxJsonBindingDescriptionParser.cs" company=" PnxSmartWDA">
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
using  PnxSmartWDA.MvvmCross.Interfaces.Converters;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform.Diagnostics;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;

namespace  PnxSmartWDA.MvvmCross.Binding.Binders.Json
{
    public class MvxJsonBindingDescriptionParser
        : IMvxBindingDescriptionParser
          , IMvxServiceConsumer<IMvxValueConverterProvider>
    {
        #region IMvxBindingDescriptionParser Members

        public IEnumerable<MvxBindingDescription> Parse(string text)
        {
            MvxJsonBindingSpecification specification;
            var parser = new MvxJsonBindingParser();
            if (!parser.TryParseBindingSpecification(text, out specification))
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error,
									  "Failed to parse binding specification starting with {0}",
				                      text == null ? "" : (text.Length > 20 ? text.Substring(0,20) : text));
                return null;
            }

            if (specification == null)
                return null;

            return from item in specification
                   let targetName = item.Key
                   let jsonDescription = item.Value
                   let converter = FindConverter(jsonDescription.Converter)
                   select new MvxBindingDescription()
                              {
                                  TargetName = targetName,
                                  SourcePropertyPath = jsonDescription.Path,
                                  Converter = converter,
                                  ConverterParameter = jsonDescription.ConverterParameter,
                                  Mode = jsonDescription.Mode,
                                  FallbackValue = jsonDescription.FallbackValue
                              };
        }

        #endregion

        private IMvxValueConverter FindConverter(string converterName)
        {
            if (string.IsNullOrWhiteSpace(converterName))
                return null;

            return this.GetService<IMvxValueConverterProvider>().Find(converterName);
        }
    }
}