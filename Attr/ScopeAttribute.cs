using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.attr
{
    /// <summary>
    /// 作用域特性类
    /// </summary>
    public class ScopeAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
