#region Copyright
// <copyright file="IMvxPictureChooserTask.cs" company=" PnxSmartWDA">
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

namespace  PnxSmartWDA.MvvmCross.Interfaces.Platform.Tasks
{
    public interface IMvxPictureChooserTask
    {
        void ChoosePictureFromLibrary(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled);
        void TakePicture(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled);
    }
}