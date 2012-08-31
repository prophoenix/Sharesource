#region Copyright
// <copyright file="MvxHttpImageView.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using  PnxSmartWDA.MvvmCross.Platform;
using  PnxSmartWDA.MvvmCross.Platform.Images;

namespace  PnxSmartWDA.MvvmCross.Binding.Android.Views
{
    public class MvxHttpImageView
        : ImageView
    {
        private readonly MvxDynamicImageHelper<Bitmap> _imageHelper;

        public MvxHttpImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            _imageHelper = new MvxDynamicImageHelper<Bitmap>();
            _imageHelper.ImageChanged += ImageHelperOnImageChanged;
            var typedArray = context.ObtainStyledAttributes(attrs,  MvxAndroidBindingResource.Instance.HttpImageViewStylableGroupId);

            int numStyles = typedArray.IndexCount;
            for (var i = 0; i < numStyles; ++i)
            {
                int attributeId = typedArray.GetIndex(i);
                if (attributeId == MvxAndroidBindingResource.Instance.HttpSourceBindId)
                {
                    ImageUrl = typedArray.GetString(attributeId);
                }
            }
            typedArray.Recycle();
        }

        public string ImageUrl
        {
            get { return Image.ImageUrl; }
            set { Image.ImageUrl = value; }
        }

#warning HttpImageUrl deprecated really
        public string HttpImageUrl
        {
            get { return Image.HttpImageUrl; }
            set { Image.HttpImageUrl = value; }
        }

        public MvxHttpImageView(Context context)
            : base(context)
        {
        }

        protected MvxHttpImageView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MvxDynamicImageHelper<Bitmap> Image { get { return _imageHelper; } }

        private void ImageHelperOnImageChanged(object sender, MvxValueEventArgs<Bitmap> mvxValueEventArgs)
        {
            SetImageBitmap(mvxValueEventArgs.Value);
        }
    }
}