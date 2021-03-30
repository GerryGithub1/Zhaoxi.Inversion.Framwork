using IOC.attr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC.bean
{
    /// <summary>
    /// 别名生成器类
    /// </summary>
    public class BeanNameGenerator
    {
        /// <summary>
        /// 生成beanName的方法
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public string GeneratorBeanName(BeanDefinition definition)
        {
            // 获取Type类型对象上面的ComponetAttribute特性
            var attr = definition.BeanClass.GetCustomAttribute<ComponetAttribute>(false);
            string beanName = attr.BeanName;
            if (!string.IsNullOrEmpty(beanName))
            {
                return beanName;
            }

            // 按照默认方式生成
            return BuildDefaultName(definition);

        }

        /// <summary>
        /// 默认是类名首字母小写生成别名
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        private string BuildDefaultName(BeanDefinition definition)
        {
            // 获取类名称
            string className = definition.BeanClass.Name;
            string beanName = className.Substring(0,1).ToLower() + className.Substring(1);

            return beanName;
        }
    }
}
