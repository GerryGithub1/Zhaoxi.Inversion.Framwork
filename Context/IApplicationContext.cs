using IOC.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context
{
    public interface IApplicationContext : IBeanFactory
    {
        void Refresh();
    }
}
