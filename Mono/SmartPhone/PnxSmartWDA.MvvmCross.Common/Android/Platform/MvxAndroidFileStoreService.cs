#region Copyright
// <copyright file="MvxAndroidFileStoreService.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
#region using

using System.IO;
using Android.Content;
using  PnxSmartWDA.MvvmCross.Android.Interfaces;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Platform;

#endregion

namespace  PnxSmartWDA.MvvmCross.Android.Platform
{
    public class MvxAndroidFileStoreService 
        : MvxBaseFileStoreService
        , IMvxServiceConsumer<IMvxAndroidGlobals>
    {
        private Context _context;
        private Context Context
        {
            get
            {
                if (_context == null)
                {
                    _context = this.GetService<IMvxAndroidGlobals>().ApplicationContext;
                }
                return _context;
            }
        }

        protected override string FullPath(string path)
        {
            return Path.Combine(Context.FilesDir.Path, path);
        }    
    }
}