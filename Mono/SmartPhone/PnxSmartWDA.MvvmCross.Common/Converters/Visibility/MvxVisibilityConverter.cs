#region Copyright
// <copyright file="MvxVisibilityConverter.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Globalization;

namespace  PnxSmartWDA.MvvmCross.Converters.Visibility
{
    public class MvxVisibilityConverter : MvxBaseVisibilityConverter
    {
        public override MvxVisibility ConvertToMvxVisibility(object value, object parameter, CultureInfo culture)
        {
            var visibility = (bool) value;
            return visibility ? MvxVisibility.Visible : MvxVisibility.Collapsed;
        }
    }
}