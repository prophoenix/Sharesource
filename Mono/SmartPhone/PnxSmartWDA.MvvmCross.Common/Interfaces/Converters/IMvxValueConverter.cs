#region Copyright
// <copyright file="IMvxValueConverter.cs" company=" PnxSmartWDA">
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

namespace  PnxSmartWDA.MvvmCross.Interfaces.Converters
{
#if WINDOWS_PHONE
    public interface IMvxValueConverter : System.Windows.Data.IValueConverter
    {        
    }
#elif NETFX_CORE
    public interface IMvxValueConverter : Windows.UI.Xaml.Data.IValueConverter
    {        
    }    
#else
    public interface IMvxValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
#endif
}