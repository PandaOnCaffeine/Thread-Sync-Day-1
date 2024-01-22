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
            RunOpgTwoAndThree();

            Console.ReadLine();
        }
        static void RunOpgOne()
        {
            Thread threadAdd = new Thread(() => add());
            Thread threadRemove = new Thread(() => remove());
            threadAdd.Start();
            threadRemove.Start();
        }
        static void RunOpgTwoAndThree()
        {
            Thread threadStar = new Thread(() => Stars());
            Thread threadHashtags = new Thread(() => Hashtags());
            threadStar.Start();
            threadHashtags.Start();
        }

        static void add()
        {
            while (true)
            {
                lock (_lock)
                {
                    _sum += 2;
                    Console.WriteLine("add: " + _sum);
                    Thread.Sleep(1000);
                }
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
                    Thread.Sleep(1000);
                }
            }
        }
        static void Stars()
        {
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        _sum++;
                        Console.Write("*");
                    }
                    Console.Write(" " + _sum);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
        static void Hashtags()
        {
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        _sum++;
                        Console.Write("#");
                    }
                    Console.Write(" " + _sum);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
