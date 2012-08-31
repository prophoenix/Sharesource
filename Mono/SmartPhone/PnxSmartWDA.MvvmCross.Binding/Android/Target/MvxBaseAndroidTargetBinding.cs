#region Copyright
// <copyright file="MvxBaseAndroidTargetBinding.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.Binding.Bindings.Target;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Target
{
    public abstract class MvxBaseAndroidTargetBinding 
        : MvxBaseTargetBinding
          , IMvxServiceConsumer<IMvxAndroidGlobals>
    {
        private IMvxAndroidGlobals _androidGlobals;
        protected IMvxAndroidGlobals AndroidGlobals
        {
            get
            {
                if (_androidGlobals == null)
                    _androidGlobals = this.GetService<IMvxAndroidGlobals>();
                return _androidGlobals;
            }
        }
    }
}