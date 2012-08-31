#region Copyright
// <copyright file="MvxBaseAndroidBindingSetup.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System;
using System.Collections.Generic;
using Android.Content;
using  PnxSmartWDA.MvvmCross.Android.Platform;
using  PnxSmartWDA.MvvmCross.Binding.Android.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Target.Construction;

namespace  PnxSmartWDA.MvvmCross.Binding.Android
{
    public abstract class MvxBaseAndroidBindingSetup
        : MvxBaseAndroidSetup
    {
        protected MvxBaseAndroidBindingSetup(Context applicationContext) 
            : base(applicationContext)
        {
        }

        protected override void InitializeLastChance()
        {
            var bindingBuilder = new MvxAndroidBindingBuilder(FillTargetFactories, FillValueConverters, SetupViewTypeResolver);
            bindingBuilder.DoRegistration();

            base.InitializeLastChance();
        }

        protected virtual void SetupViewTypeResolver(MvxViewTypeResolver viewTypeResolver)
        {
            viewTypeResolver.ViewNamespaceAbbreviations = this.ViewNamespaceAbbreviations;
        }

        protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            var holders = ValueConverterHolders;
            if (holders == null)
                return;

            var filler = new MvxInstanceBasedValueConverterRegistryFiller(registry);
            var staticFiller = new MvxStaticBasedValueConverterRegistryFiller(registry);
            foreach (var converterHolder in holders)
            {
                filler.AddFieldConverters(converterHolder);
                staticFiller.AddStaticFieldConverters(converterHolder);
            }
        }

        protected virtual IEnumerable<Type> ValueConverterHolders
        {
            get { return null; }
        }

        protected virtual IDictionary<string, string> ViewNamespaceAbbreviations
        {
            get
            {
                return new Dictionary<string, string>()
                           {
                               { "Mvx", " PnxSmartWDA.MvvmCross.Binding.Android.Views" }
                           };
            }
        }

        protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            // nothing to do in this base class
        }
    }
}