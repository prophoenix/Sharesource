#region Copyright
// <copyright file="MvxAndroidBindingBuilder.cs" company=" PnxSmartWDA">
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
using Android.Widget;
using  PnxSmartWDA.MvvmCross.Binding.Android.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Android.Interfaces.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Android.Target;
using  PnxSmartWDA.MvvmCross.Binding.Android.Views;
using  PnxSmartWDA.MvvmCross.Binding.Bindings.Target.Construction;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Binders;
using  PnxSmartWDA.MvvmCross.Binding.Interfaces.Bindings.Target.Construction;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;

namespace  PnxSmartWDA.MvvmCross.Binding.Android
{
    public class MvxAndroidBindingBuilder
        : MvxBaseBindingBuilder
        , IMvxServiceProducer<IMvxViewTypeResolver>
    {
        private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
        private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;
        private readonly Action<MvxViewTypeResolver> _setupViewTypeResolver;

        public MvxAndroidBindingBuilder(
            Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction, 
            Action<IMvxValueConverterRegistry> fillValueConvertersAction,
            Action<MvxViewTypeResolver> setupViewTypeResolver)
        {
            _fillRegistryAction = fillRegistryAction;
            _fillValueConvertersAction = fillValueConvertersAction;
            _setupViewTypeResolver = setupViewTypeResolver;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(MvxEditTextTextTargetBinding), typeof(EditText), "Text"));
            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(MvxAutoCompleteTextViewPartialTextTargetBinding), typeof(AutoCompleteTextView), "PartialText"));
            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(MvxAutoCompleteTextViewSelectedObjectTargetBinding), typeof(AutoCompleteTextView), "SelectedObject"));
            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(MvxCompoundButtonCheckedTargetBinding), typeof(CompoundButton), "Checked"));
            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(MvxSeekBarProgressTargetBinging), typeof(SeekBar), "Progress"));
            registry.RegisterFactory(new MvxCustomBindingFactory<ImageView>("AssetImagePath", imageView => new MvxImageViewDrawableTargetBinding(imageView)));
            registry.RegisterFactory(new MvxCustomBindingFactory<MvxBindableSpinner>("SelectedItem", spinner => new MvxSpinnerSelectedItemBinding(spinner)));

            if (_fillRegistryAction != null)
                _fillRegistryAction(registry);
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);

            if (_fillValueConvertersAction != null)
                _fillValueConvertersAction(registry);
        }

        protected override void RegisterPlatformSpecificComponents()
        {
            base.RegisterPlatformSpecificComponents();

            InitialiseViewTypeResolver();
        }

        private void InitialiseViewTypeResolver()
        {
            var viewTypeResolver = new MvxViewTypeResolver();
            _setupViewTypeResolver(viewTypeResolver);
            this.RegisterServiceInstance<IMvxViewTypeResolver>(viewTypeResolver);
        }
    }
}