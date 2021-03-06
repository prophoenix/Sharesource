﻿#region Copyright
// <copyright file="MvxDictionaryBaseTextProvider.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Generic;
using  PnxSmartWDA.MvvmCross.Platform.Diagnostics;

namespace  PnxSmartWDA.MvvmCross.Localization
{
    public class MvxDictionaryBaseTextProvider : MvxBaseTextProvider
    {
        private readonly Dictionary<string, string> _entries = new Dictionary<string, string>();
        private readonly bool _maskErrors;

        public MvxDictionaryBaseTextProvider(bool maskErrors)
        {
            _maskErrors = maskErrors;
        }
        protected void AddOrReplace(string namespaceKey, string typeKey, string name, string value)
        {
            var key = MakeLookupKey(namespaceKey, typeKey, name);
            _entries[key] = value;
        }

        #region Implementation of IMvxTextProvider

        public override string GetText(string namespaceKey, string typeKey, string name)
        {
            var key = MakeLookupKey(namespaceKey, typeKey, name);
            string value;
            if (_entries.TryGetValue(key, out value))
                return value;

            MvxTrace.Trace("Text value missing for " + key);
            if (_maskErrors)
                return key;

            throw new KeyNotFoundException("Could not find text lookup for " + key);
        }

        #endregion
    }
}
