using IOC.bean;
using IOC.factory;
using IOC.registry;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Inversion.Framwork.Attr;

namespace IOC.defaultcontext
{
    /// <summary>
    /// IOC容器默认实现
    /// </summary>
    public class DefaultListableBeanFactory : IBeanFactory,IRegistryBeanDefinition
    {
        // 创建IOC容器（字典对象）
        public ConcurrentDictionary<string, BeanDefinition> beanDefintionDict = new ConcurrentDictionary<string, BeanDefinition>();

        /// <summary>
        /// 通过反射来动态创建指定别名称类的实例
        /// </summary>
        /// <param name="beanName"></param>
        /// <returns></returns>
        public object GetBean(string beanName)
        {
            BeanDefinition value;
            beanDefintionDict.TryGetValue(beanName, out value);
            // 有对象Type实例但是对应依赖对象是为null
            var obj=  Activator.CreateInstance(value.BeanClass);
            // 执行依赖注入（反射）
            PouplateBean(obj);
            
            return obj;
        }

        /// <summary>
        /// 依赖注入的方法
        /// </summary>
        /// <param name="obj"></param>
        private void PouplateBean(object obj)
        {
            // 获取对象实例类型
            Type type = obj.GetType();
            // 获取所有定义的字段数组
            FieldInfo[] propertyInfos = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo item in propertyInfos)
            {
                string injectName = item.Name;
                // 判断是否标记自动装配特性
                AutowriedAttribute attr = item.GetCustomAttribute<AutowriedAttribute>();
                string autowiredName = attr.BeanName;
                if (attr !=  null && autowiredName != null)
                {
                    injectName = autowiredName;
                }
                // 默认安装名称装配,获取对应的实例
                object injectInstance = GetBean(injectName);
                // 给字段赋值
                item.SetValue(obj, injectInstance);
            }
        }

        /// <summary>
        /// 真正在IOC容器中进行管理BeanDefintion对象的注册
        /// </summary>
        /// <param name="beanName"></param>
        /// <param name="beanDefinition"></param>
        public void RegistryBeanDefinition(string beanName, BeanDefinition beanDefinition)
        {
            if (beanDefintionDict.ContainsKey(beanName))
            {
                throw new Exception("注册BeanDefinition出现问题");
            }
            beanDefintionDict.TryAdd(beanName, beanDefinition);
            Console.WriteLine("注入的对象有:" + beanDefinition.BeanName);
        }
    }
}
