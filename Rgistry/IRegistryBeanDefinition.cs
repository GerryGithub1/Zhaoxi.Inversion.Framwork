using IOC.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.registry
{
    public interface IRegistryBeanDefinition
    {
        void RegistryBeanDefinition(string beanName, BeanDefinition beanDefinition);
    }
}
