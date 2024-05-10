using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class MonitorExample
    {
        private readonly object _lock = new object();

        public void Enter()
        {
            Monitor.Enter(_lock);
        }

        public void Exit()
        {
            Monitor.Exit(_lock);
        }

        public void Wait()
        {
            Monitor.Wait(_lock);
        }

        public void Pulse()
        {
            Monitor.Pulse(_lock);
        }

        public void PulseAll()
        {
            Monitor.PulseAll(_lock);
        }

        public bool TryEnter()
        {
            return Monitor.TryEnter(_lock);
        }
    }
    public class MonitorClassDemo
    {
        static void Main(string[] args)
        {
            MonitorExample monitor = new MonitorExample();

            // Thread 1
            new Thread(() =>
            {
                monitor.Enter();
                Console.WriteLine("Thread 1 entered lock");
                Thread.Sleep(2000); // Simulating some work
                monitor.Wait(); // Thread 1 waits
                Console.WriteLine("Thread 1 resumed");
                monitor.Exit();
            }).Start();

            // Thread 2
            new Thread(() =>
            {
                Thread.Sleep(1000); // Simulating some delay
                monitor.Enter();
                Console.WriteLine("Thread 2 entered lock");
                monitor.Pulse(); // Notify Thread 1
                monitor.Exit();
            }).Start();

            Console.ReadLine();
        }
    }
}
