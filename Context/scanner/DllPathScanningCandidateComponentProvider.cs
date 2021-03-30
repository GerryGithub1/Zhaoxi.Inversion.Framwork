using IOC.attr;
using IOC.bean;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context.scanner
{
    /// <summary>
    /// DLL扫描前的提供类，主要做一些初始化操作
    /// </summary>
    public class DllPathScanningCandidateComponentProvider
    {
        public List<string> IncludeFilters { get; set; } = new List<string>();

        /// <summary>
        /// 注册默认的特性
        /// </summary>
        protected void RegisterDefaultFilters()
        {
            IncludeFilters.Add(typeof(ComponetAttribute).Name);
        }

        /// <summary>
        /// 扫描符合条件的BeanDefinition集合
        /// </summary>
        /// <param name="dllpath"></param>
        /// <returns></returns>
        public List<BeanDefinition> ScanCandidateComponents(string dllpath)
        {
            var list = new List<BeanDefinition>();
            // 反射加载的dll和项目引用dll是同一个吗？TokenKey 都是null
            Assembly assembly = Assembly.LoadFile(dllpath);
            // 需要获取所有的标记了ComponetAttribute特性的类
            var types = assembly.GetTypes().Where(t => t.IsDefined(typeof(ComponetAttribute), true));

            foreach (var type in types)
            {
                // 判断不能是接口和抽象类
                if (!type.IsInterface && !type.IsAbstract)
                {
                    // 封装为BeanDefinition
                    BeanDefinition beanDefinition = new BeanDefinition();
                    beanDefinition.BeanClass = type;
                    // 添加到集合
                    list.Add(beanDefinition);
                }
            }

            // 最后去重返回
            return list.Distinct().ToList();
        }
    }
}
