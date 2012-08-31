#region Copyright
// <copyright file="MvxSourceBindingFactory.cs" company=" PnxSmartWDA">
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
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Source;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Source.Construction;

namespace  PnxSmartWDA.MvvmCross.Binding.Bindings.Source.Construction
{
    public class MvxSourceBindingFactory : IMvxSourceBindingFactory
    {
        private static readonly char[] FieldSeparator = new [] { '.' };

        #region IMvxSourceBindingFactory Members

        public IMvxSourceBinding CreateBinding(object source, string combinedPropertyName)
        {
            if (combinedPropertyName == null)
                combinedPropertyName = "";
            
            return CreateBinding(source, combinedPropertyName.Split(FieldSeparator , StringSplitOptions.RemoveEmptyEntries));
        }

        public IMvxSourceBinding CreateBinding(object source, IEnumerable<string> childPropertyNames)
        {
            var childPropertyNameList = childPropertyNames.ToList();

            switch (childPropertyNameList.Count)
            {
                case 0:
                    return new MvxDirectToSourceBinding(source);
                case 1:
                    return new MvxPropertyInfoSourceBinding(source, childPropertyNameList.DefaultIfEmpty(string.Empty).FirstOrDefault());
                default:
                   return new MvxChainedSourceBinding(source, childPropertyNameList.First(), childPropertyNameList.Skip(1));
            }

        }

        #endregion
    }
}