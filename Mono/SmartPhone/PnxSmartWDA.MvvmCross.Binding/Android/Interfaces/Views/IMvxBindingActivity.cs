#region Copyright
// <copyright file="IMvxBindingActivity.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.Views;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Interfaces.Views
{
    public interface IMvxBindingActivity
    {
        void ClearBindings(View view);
        View BindingInflate(object source, int resourceId, ViewGroup viewGroup);
        View BindingInflate(int resourceId, ViewGroup viewGroup);
        View NonBindingInflate(int resourceId, ViewGroup viewGroup);
    }
}