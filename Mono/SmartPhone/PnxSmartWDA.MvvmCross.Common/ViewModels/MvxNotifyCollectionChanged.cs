#region Copyright
// <copyright file="MvxNotifyCollectionChanged.cs" company=" PnxSmartWDA">
// (c) Copyright  PnxSmartWDA. http://www. PnxSmartWDA.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
// 
// Project Lead - Stuart Lodge,  PnxSmartWDA. http://www. PnxSmartWDA.com
#endregion

using System.Collections.Specialized;
using  PnxSmartWDA.MvvmCross.ExtensionMethods;
using  PnxSmartWDA.MvvmCross.Interfaces.ServiceProvider;
using  PnxSmartWDA.MvvmCross.Interfaces.Views;

namespace  PnxSmartWDA.MvvmCross.ViewModels
{
    public abstract class MvxNotifyCollectionChanged
        : INotifyCollectionChanged
          , IMvxServiceConsumer<IMvxViewDispatcherProvider>
    {
        protected IMvxViewDispatcher ViewDispatcher
        {
            get { return this.GetService<IMvxViewDispatcherProvider>().Dispatcher; }
        }

        #region Implementation of INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion

        protected void FireCollectionReset()
        {
            FireCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected void FireCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            // check for subscription before going multithreaded
            if (CollectionChanged == null)
                return;

            if (ViewDispatcher != null)
                ViewDispatcher.RequestMainThreadAction(
                    () =>
                        {
                            // take a copy - see RoadWarrior's answer on http://stackoverflow.com/questions/282653/checking-for-null-before-event-dispatching-thread-safe/282741#282741
                            var handler = CollectionChanged;

                            if (handler != null)
                                handler(this, args);
                        });
        }
    }
}