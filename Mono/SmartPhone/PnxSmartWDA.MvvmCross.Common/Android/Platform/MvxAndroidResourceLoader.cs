﻿#region Copyright
// <copyright file="MvxAndroidResourceLoader.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.IO;
using Android.Content.Res;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Platform;

namespace  PnxSmartWDA.MvvmCross.Android.Platform
{
    public class MvxAndroidResourceLoader 
        : MvxBaseResourceLoader
        , IMvxServiceConsumer<IMvxAndroidGlobals>
    {
        private AssetManager _assets;

        public MvxAndroidResourceLoader()
        {
        }

        #region Implementation of IMvxResourceLoader

        public override void GetResourceStream(string resourcePath, Action<Stream> streamAction)
        {
#warning ? need to check and clarify what exceptions can be thrown here!
            using (var input = Assets.Open(resourcePath))
            {
                streamAction(input);
            }
        }

        #endregion

        private AssetManager Assets
        {
            get
            {
                if (_assets == null)
                {
                    _assets = this.GetService<IMvxAndroidGlobals>().ApplicationContext.Assets;
                }
                return _assets;
            }
        }
    }
}
