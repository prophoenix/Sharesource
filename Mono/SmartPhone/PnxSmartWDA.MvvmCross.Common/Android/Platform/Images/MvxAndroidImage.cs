#region Copyright
// <copyright file="MvxAndroidImage.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using Android.Graphics;
using  PnxSmartWDA.MvvmCross.Platform.Images;

namespace  PnxSmartWDA.MvvmCross.Android.Platform.Images
{
    public class MvxAndroidImage
        : MvxImage<Bitmap>
    {
        public MvxAndroidImage(Bitmap rawImage) 
            : base(rawImage)
        {
        }

        public override int GetSizeInBytes()
        {
            if (RawImage == null)
                return 0;

            return RawImage.RowBytes*RawImage.Height;
        }
    }
}