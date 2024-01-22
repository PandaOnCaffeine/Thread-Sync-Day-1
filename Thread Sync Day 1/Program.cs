using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Thread_Sync_Day_1
{
    internal class Program
    {
        static int _sum = 0;
        static object _lock = new object();
        static void Main(string[] args)
        {
            RunOpgOne();

            Console.ReadLine();
        }
        static void RunOpgOne()
        {
            Thread threadAdd = new Thread(() => add());
            Thread threadRemove = new Thread(() => remove());
            threadAdd.Start();
            threadRemove.Start();
        }

        static void add()
        {
            while (true)
            {
                lock (_lock)
                {
                    _sum += 2;
                    Console.WriteLine("add: " + _sum);
                }
                Thread.Sleep(1000);
            }
        }
        static void remove()
        {
            while (true)
            {
                lock (_lock)
                {
                    _sum--;
                    Console.WriteLine("Remove: " + _sum);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
