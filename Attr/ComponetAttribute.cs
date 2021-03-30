using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.attr
{
    /// <summary>
    /// 根特性类
    /// </summary>
    public class ComponetAttribute : Attribute
    {
        public string BeanName { get; set; }
    }
}
