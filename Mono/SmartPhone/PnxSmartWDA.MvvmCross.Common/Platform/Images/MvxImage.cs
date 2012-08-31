#region Copyright
// <copyright file="MvxImage.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion
namespace  PnxSmartWDA.MvvmCross.Platform.Images
{
    public abstract class MvxImage<T>
    {
        protected MvxImage(T rawImage)
        {
            RawImage = rawImage;
        }

        public T RawImage { get; private set; }
        public abstract int GetSizeInBytes();
    }
}