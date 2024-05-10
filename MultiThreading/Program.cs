using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    // [Synchronization]
    public class Demo
    {
        public void Print1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
        public void Print2()
        {
            for (int i = 11; i <= 20; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
        public void Print3()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            lock (this)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                }
            }

        }


    }

    public class Program
    {
        //static void Main(string[] args)
        //{
        //    Demo demo = new Demo();
        //    Thread t1 = new Thread(new ThreadStart(demo.Print1));
        //    Thread t2 = new Thread(new ThreadStart(demo.Print2));
        //    t1.Name = "Thread1";
        //    t2.Name = "Thread2";

        //    t1.Start();
        //    t2.Start();

        //}
    }
}
