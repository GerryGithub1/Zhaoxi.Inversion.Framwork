using IOC.registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.bean
{
    /// <summary>
    /// bean定义主从工具类
    /// </summary>
    public class BeanDefinitionUtils
    {
        //this => IOCScanningConfigApplictionContext实例
        public static void BeanRegistry(BeanDefinition beanDefinition,IRegistryBeanDefinition registry)
        {
            registry.RegistryBeanDefinition(beanDefinition.BeanName, beanDefinition);
        }
    }
}
