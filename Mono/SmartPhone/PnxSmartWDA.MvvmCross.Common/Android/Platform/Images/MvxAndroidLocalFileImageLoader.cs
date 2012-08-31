#region Copyright
// <copyright file="MvxAndroidLocalFileImageLoader.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.Graphics;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Platform;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Platform.Images;

namespace  PnxSmartWDA.MvvmCross.Android.Platform.Images
{
    public class MvxAndroidLocalFileImageLoader
        : IMvxLocalFileImageLoader<Bitmap>
        , IMvxServiceConsumer<IMvxSimpleFileStoreService>
    {
        #region IMvxLocalFileImageLoader<UIImage> Members

        public MvxImage<Bitmap> Load(string localPath, bool shouldCache)
        {
            var bitmap = LoadBitmap(localPath, shouldCache);
            return new MvxAndroidImage(bitmap);
        }

        private Bitmap LoadBitmap(string localPath, bool shouldCache)
        {
            var fileStore = this.GetService<IMvxSimpleFileStoreService>();
            byte[] contents;
            if (!fileStore.TryReadBinaryFile(localPath, out contents))
                return null;

            var image = BitmapFactory.DecodeByteArray(contents, 0, contents.Length);
            return image;
        }

        #endregion
    }
}