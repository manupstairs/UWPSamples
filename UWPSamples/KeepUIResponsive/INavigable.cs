using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepUIResponsive
{
    public interface INavigable
    {
        void OnNavigatedFrom(object obj);

        void OnNavigatedTo(object obj);
    }
}
