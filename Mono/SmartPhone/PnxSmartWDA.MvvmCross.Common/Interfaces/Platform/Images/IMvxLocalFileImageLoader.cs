#region Copyright
// <copyright file="IMvxLocalFileImageLoader.cs" company=" PnxSmartWDA">
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
    public interface IMvxLocalFileImageLoader<T>
    {
        MvxImage<T> Load(string localPath, bool shouldCache);
    }
}