using IOC.bean;
using IOC.registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.context.scanner
{
    /// <summary>
    /// BeanDefintion的扫描和注册类
    /// </summary>
    public class DllPathBeanDefinitionScanner : DllPathScanningCandidateComponentProvider
    {
        public IRegistryBeanDefinition registry;

        private BeanNameGenerator beanNameGenerator = new BeanNameGenerator();
        private BeanScopeConfig scopeConfig = new BeanScopeConfig();

        public DllPathBeanDefinitionScanner(IRegistryBeanDefinition registry) 
            : this(registry, true)
        {
           
        }

        public DllPathBeanDefinitionScanner(IRegistryBeanDefinition registry, bool isDefault)
        {
            this.registry = registry;
            // 注册默认特性
            if (isDefault)
            {
                RegisterDefaultFilters();
            }
        }

        /// <summary>
        /// 扫描前判断是否存在需要扫描的
        /// </summary>
        /// <param name="dllpaths"></param>
        public void Scan(string[] dllpaths)
        {
            if (dllpaths != null && dllpaths.Length == 0)
            {
                return;
            }

            DoScan(dllpaths);
        }

        /// <summary>
        /// 真正的执行扫描操作
        /// </summary>
        /// <param name="dllpaths"></param>
        private void DoScan(string[] dllpaths)
        {
            foreach (var path in dllpaths)
            {
                // 获取所有扫描到符合条件的BeanDefinition集合
                List<BeanDefinition> candidates = ScanCandidateComponents(path);
                foreach (var benDef in candidates)
                {
                    // 创建别名设置（默认为类的首字母小写，设置了别名就是用设置的）
                    string beanName = beanNameGenerator.GeneratorBeanName(benDef);
                    benDef.BeanName = beanName;
                    // 作用域配置
                    string scopeName = scopeConfig.ConfigScope(benDef);
                    benDef.ScopName = scopeName;
                    // 注册到IOC容器中
                    RegistryBeanDefinition(benDef, registry);
                }
            }
        }

        /// <summary>
        /// 注册BeanDefinition
        /// </summary>
        /// <param name="benDef"></param>
        /// <param name="registry"></param>
        private void RegistryBeanDefinition(BeanDefinition benDef, IRegistryBeanDefinition registry)
        {
            BeanDefinitionUtils.BeanRegistry(benDef, registry);
        }
    }
}
