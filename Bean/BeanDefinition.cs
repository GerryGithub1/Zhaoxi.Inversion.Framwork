using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IOC.bean
{
    /// <summary>
    /// Bean定义模型类
    /// </summary>
    public class BeanDefinition
    {
        public static readonly string SINGLETION_SCOPE = "singleton";
        public static readonly string PROTOTYPE_SCOPE = "prototype";

        public string BeanName { get; set; }
        public Type BeanClass { get; set; }
        public string ScopName { get; set; } = SINGLETION_SCOPE;
    }
}
