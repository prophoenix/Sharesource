using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SmartDevice.Core.Models
{
    public interface IObservableCollection<T>
        : IList<T>
        , INotifyCollectionChanged
    {
    }
}