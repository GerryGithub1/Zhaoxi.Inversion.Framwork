using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Inversion.Framwork.Attr
{
    public class AutowriedAttribute : Attribute
    {
        public string BeanName { get; set; }
    }
}
