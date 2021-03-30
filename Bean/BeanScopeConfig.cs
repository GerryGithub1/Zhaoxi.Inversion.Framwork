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
    /// Bean的作用域装配
    /// </summary>
    public class BeanScopeConfig
    {
        /// <summary>
        /// 设置BeanDefinition的作用域
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public string ConfigScope(BeanDefinition definition)
        {
            // 规则实例的默认作用域为Singleton
            string scopeName = BeanDefinition.SINGLETION_SCOPE;
            var attr = definition.BeanClass.GetCustomAttribute<ScopeAttribute>();
            if (null != attr)
            {
                string scopeString = attr.Name;
                if (!string.IsNullOrEmpty(scopeString))
                {
                    scopeName = scopeString;
                }
            }
            
            return scopeName;
        }
    }
}
