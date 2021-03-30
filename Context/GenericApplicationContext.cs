using IOC.bean;
using IOC.defaultcontext;
using IOC.registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context
{
    /// <summary>
    /// 应用抽象类(核心处理放到抽象)
    /// </summary>
    public class GenericApplicationContext : AbstractApplicationContext,IRegistryBeanDefinition 
    {
        
        private DefaultListableBeanFactory beanFactory;

        public GenericApplicationContext()
        {
            // 创建IOC容器默认的实现类实例
            this.beanFactory = new DefaultListableBeanFactory();
        }

        public override object GetBean(string beanName)
        {
            return this.beanFactory.GetBean(beanName);
        }

        public DefaultListableBeanFactory GetBeanFactory()
        {
            return this.beanFactory;
        }

        /// <summary>
        /// BeanDefintion对象注册到IOC的方法
        /// </summary>
        /// <param name="beanName"></param>
        /// <param name="beanDefinition"></param>
        public void RegistryBeanDefinition(string beanName, BeanDefinition beanDefinition)
        {
            beanFactory.RegistryBeanDefinition(beanName, beanDefinition);
        }
    }
}
