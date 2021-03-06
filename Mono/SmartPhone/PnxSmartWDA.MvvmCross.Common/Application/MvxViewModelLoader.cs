#region Copyright
// <copyright file="MvxViewModelLoader.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using  PnxSmartWDA.MvvmCross.Exceptions;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.Application;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.ViewModels;
using  PnxSmartWDA.MvvmCross.ViewModels;
using  PnxSmartWDA.MvvmCross.Views;

namespace  PnxSmartWDA.MvvmCross.Application
{
    public class MvxViewModelLoader
        : IMvxViewModelLoader
          , IMvxServiceConsumer<IMvxViewModelLocatorFinder>
    {
        #region IMvxViewModelLoader Members

        public IMvxViewModel LoadViewModel(MvxShowViewModelRequest request)
        {
            if (request.ViewModelType == typeof(MvxNullViewModel))
                return new MvxNullViewModel();

            var viewModelLocatorFinder = this.GetService<IMvxViewModelLocatorFinder>();
            var viewModelLocator = viewModelLocatorFinder.FindLocator(request);

            if (viewModelLocator == null)
                throw new MvxException("Sorry - somehow there's no viewmodel locator registered for {0}",
                                       request.ViewModelType);

            IMvxViewModel model = null;
            if (!viewModelLocator.TryLoad(request.ViewModelType, request.ParameterValues, out model))
                throw new MvxException(
                    "Failed to load ViewModel for type {0} from locator {1}",
                    request.ViewModelType, viewModelLocator.GetType().Name);

            if (model != null)
                model.RequestedBy = request.RequestedBy;

            return model;
        }

        #endregion
    }
}