using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context
{
    public abstract class AbstractApplicationContext : IApplicationContext
    {
        public abstract object GetBean(string beanName);

        /// <summary>
        /// IOC容器刷新方法
        /// </summary>
        public void Refresh()
        {

        }
    }
}
