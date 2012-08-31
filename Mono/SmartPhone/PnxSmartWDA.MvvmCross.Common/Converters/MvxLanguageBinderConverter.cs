#region Copyright
// <copyright file="MvxLanguageBinderConverter.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Globalization;
using  PnxSmartWDA.MvvmCross.Interfaces.Localization;

namespace  PnxSmartWDA.MvvmCross.Converters
{
    public class MvxLanguageBinderConverter 
        : MvxBaseValueConverter
    {
        #region Implementation of IValueConverter

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var binder = value as IMvxLanguageBinder;
            if (binder == null)
                return null;

            if (parameter == null)
                return null;

            return binder.GetText(parameter.ToString());
        }

        #endregion
    }
}
