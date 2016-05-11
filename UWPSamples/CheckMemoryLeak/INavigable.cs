using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMemoryLeak
{
    public interface INavigable
    {
        event EventHandler<NavigationEventArgs> NavigateEvent;

        event EventHandler GoBackEvent;

        void OnNavigatedTo(object obj);

        void OnNavigatedFrom(object obj);


    }
}
