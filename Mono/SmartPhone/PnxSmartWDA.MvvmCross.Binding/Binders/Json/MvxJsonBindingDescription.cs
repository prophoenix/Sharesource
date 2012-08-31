#region Copyright
// <copyright file="MvxJsonBindingDescription.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Binding.Interfaces;

namespace  PnxSmartWDA.MvvmCross.Binding.Binders.Json
{
#if MONOTOUCH
    [MonoTouch.Foundation.Preserve(AllMembers = true)]
#endif
    public class MvxJsonBindingDescription
    {
        public string Path { get; set; }
        public string Converter { get; set; }
        public string ConverterParameter { get; set; }
        public string FallbackValue { get; set; }
        public MvxBindingMode Mode { get; set; }
    }
}