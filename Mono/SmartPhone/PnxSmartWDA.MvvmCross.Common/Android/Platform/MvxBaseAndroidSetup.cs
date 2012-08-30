#region Copyright
// <copyright file="MvxBaseAndroidSetup.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Android.Graphics;
using PnxSmartWDA.MvvmCross.Android.Interfaces;
using PnxSmartWDA.MvvmCross.Android.Platform.Images;
using PnxSmartWDA.MvvmCross.Android.Views;
using PnxSmartWDA.MvvmCross.ExtensionMethods;
using PnxSmartWDA.MvvmCross.Interfaces.Platform.Images;
using PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using PnxSmartWDA.MvvmCross.Platform;
using PnxSmartWDA.MvvmCross.Platform.Images;
using PnxSmartWDA.MvvmCross.Views;

namespace PnxSmartWDA.MvvmCross.Android.Platform
{
    public abstract class MvxBaseAndroidSetup
        : MvxBaseSetup
        , IMvxAndroidGlobals
        , IMvxServiceProducer<IMvxAndroidViewModelRequestTranslator>
        , IMvxServiceProducer<IMvxAndroidViewModelLoader>
        , IMvxServiceProducer<IMvxAndroidContextSource>
        , IMvxServiceProducer<IMvxIntentResultSink>
        , IMvxServiceProducer<IMvxIntentResultSource>
        , IMvxServiceProducer<IMvxAndroidGlobals>
        , IMvxServiceProducer<IMvxAndroidSubViewModelCache>
        , IMvxServiceProducer<IMvxLocalFileImageLoader<Bitmap>>
        , IMvxServiceProducer<IMvxImageCache<Bitmap>>
        , IMvxServiceProducer<IMvxHttpFileDownloader>
    {
        private readonly Context _applicationContext;

        protected MvxBaseAndroidSetup(Context applicationContext)
        {
            _applicationContext = applicationContext;
        }



        #region IMvxAndroidGlobals Members

        public virtual string ExecutableNamespace { get { return GetType().Namespace; } }
        public virtual Assembly ExecutableAssembly { get { return GetType().Assembly; } }
        public Context ApplicationContext { get { return _applicationContext; } }

        #endregion

        protected override void InitializeAdditionalPlatformServices()
        {
            MvxAndroidServiceProvider.Instance.RegisterPlatformContextTypes(_applicationContext);
            this.RegisterServiceInstance<IMvxAndroidGlobals>(this);
            InitialiseBitmapImageProviders();

            var intentResultRouter = new MvxIntentResultSink();
            this.RegisterServiceInstance<IMvxIntentResultSink>(intentResultRouter);
            this.RegisterServiceInstance<IMvxIntentResultSource>(intentResultRouter);
        }

        protected virtual void InitialiseBitmapImageProviders()
        {
            this.RegisterServiceInstance<IMvxHttpFileDownloader>(new MvxHttpFileDownloader());

            var fileDownloadCache = new MvxFileDownloadCache("_PicturesMvvmCross", "_Caches/Pictures.MvvmCross/", 500, TimeSpan.FromDays(3.0));
            var fileCache = new MvxImageCache<Bitmap>(fileDownloadCache, 30, 4000000);
            this.RegisterServiceInstance<IMvxImageCache<Bitmap>>(fileCache);

            this.RegisterServiceInstance<IMvxLocalFileImageLoader<Bitmap>>(new MvxAndroidLocalFileImageLoader());
        }

        protected sealed override MvxViewsContainer CreateViewsContainer()
        {
            var container = CreateViewsContainer(_applicationContext);
            this.RegisterServiceInstance<IMvxAndroidViewModelRequestTranslator>(container);
            this.RegisterServiceInstance<IMvxAndroidViewModelLoader>(container);
            return container;
        }

        protected virtual IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAndroidViewPresenter();
        }

        protected override MvvmCross.Interfaces.Views.IMvxViewDispatcherProvider CreateViewDispatcherProvider()
        {
            var presenter = CreateViewPresenter();
            return new MvxAndroidViewDispatcherProvider(presenter);
        }

        protected override void InitializeLastChance()
        {
            this.RegisterServiceInstance<IMvxAndroidSubViewModelCache>(new MvxAndroidSubViewModelCache());
            base.InitializeLastChance();
        }

        protected virtual MvxAndroidViewsContainer CreateViewsContainer(Context applicationContext)
        {
            return new MvxAndroidViewsContainer(applicationContext);
        }

        protected override IDictionary<System.Type, System.Type> GetViewModelViewLookup()
        {
            return GetViewModelViewLookup(ExecutableAssembly, typeof(IMvxAndroidView));
        }
    }
}