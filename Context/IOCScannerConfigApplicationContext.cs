using IOC.context.scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context
{
    /// <summary>
    /// 基于IOC容器的扫描纳入管理
    /// </summary>
    public class IOCScannerConfigApplicationContext : GenericApplicationContext
    {
        private DllPathBeanDefinitionScanner scanner;
        public IOCScannerConfigApplicationContext()
        {
            // 创建扫描器对象
            scanner = new DllPathBeanDefinitionScanner(this);
        }

        public IOCScannerConfigApplicationContext(params string[] dllpaths) : this()
        {
            // 扫描dll文件
            scanner.Scan(dllpaths);
            // 刷新容器
            Refresh(); // 真正落地依赖倒置原则核心实现
        }
    }
}
