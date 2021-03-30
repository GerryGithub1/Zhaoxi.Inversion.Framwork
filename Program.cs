using IOC.defaultcontext;
using System;

namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //DefaultListableBeanFactory defaultListableBeanFactory = new DefaultListableBeanFactory();
            Console.WriteLine(typeof(Program).FullName);

            Console.ReadKey();
        }
    }
}
