using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.factory
{
    public interface IBeanFactory
    {
        object GetBean(string beanName);
    }
}
