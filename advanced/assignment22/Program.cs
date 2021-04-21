using System;
// using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace assignment22
{
    class Program
    {
        private static ConcurrentStack<int> myStack = new ConcurrentStack<int>();
        private static Thread t1;
        private static Thread t2;
        static void Main(string[] args)
        {
            t1 = new Thread(new ParameterizedThreadStart(AddNumbers));
            t2 = new Thread(new ParameterizedThreadStart(AddNumbers));
            Thread t3 = new Thread(new ThreadStart(ReadNumbers));
            t3.Name = "t3";
            Thread t4 = new Thread(new ThreadStart(ReadNumbers));
            t4.Name = "t4";

            t1.Start(100000);
            t2.Start(100000);
            t3.Start();
            t4.Start();

        }
        private static void ReadNumbers()
        {
            while(t1.ThreadState == ThreadState.Unstarted || t2.ThreadState == ThreadState.Unstarted);
            while(t1.IsAlive || t2.IsAlive)
            {
                System.Console.WriteLine($"Thread ({Thread.CurrentThread.Name}) counts: {myStack.Count}");
            }
        }

        private static void AddNumbers(object maxNumbers)
        {
            for (var i = 0; i < int.Parse(maxNumbers.ToString()); i++)
            {
                // System.Console.WriteLine("psuh");
                myStack.Push(i);
            }
        }
    }
}


/* Instructor solution:

 class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            int threadThreeAccessCounter = 0;
            int threadFourAccessCounter = 0;

            Thread t1 = new Thread(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    stack.Push(i);
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                for (int i = 11; i <= 20; i++)
                {
                    stack.Push(i);
                }
            });
            t2.Start();

            Thread t3 = new Thread(() =>
            {
                int stackValue = 0;
                foreach (int item in stack)
                {
                    stack.TryPop(out stackValue);
                    if (stackValue != 0)
                    {
                        Console.WriteLine("Now Thread (3) is accessing " + stackValue );
                        threadThreeAccessCounter++;
                    }

                }
            });
            t3.Start();

            Thread t4 = new Thread(() =>
            {
                int stackValue = 0;
                foreach (int item in stack)
                {
                    stack.TryPop(out stackValue);
                    if (stackValue != 0)
                    {
                        Console.WriteLine("Now Thread (4) is accessing " + stackValue );
                        threadFourAccessCounter++;
                    }
                }
            });
            t4.Start();

            Thread.Sleep(10);
            Console.WriteLine("\nThread (3) accessed " + threadThreeAccessCounter);
            Console.WriteLine("Thread (4) accessed " + threadFourAccessCounter);
        }
    }

*/