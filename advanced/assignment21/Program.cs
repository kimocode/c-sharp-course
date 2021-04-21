using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace assignment21
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource c1 = new CancellationTokenSource();
            CancellationTokenSource c2 = new CancellationTokenSource();
            ConcurrentDictionary<int, int> dict = new ConcurrentDictionary<int, int>();

            Task t1 = new Task(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    if(c1.IsCancellationRequested) {
                        System.Console.WriteLine("C1 cancelled");   
                        System.Console.WriteLine("2 won, 1 finished: " + dict[1]);                     
                        return;                      
                    }
                    dict.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
                    System.Console.WriteLine("1: " + i);
                }
                c2.Cancel();
            }, c1.Token);

            Task t2 = new Task(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    if(c1.IsCancellationRequested) {
                        System.Console.WriteLine("C2 cancelled");   
                        System.Console.WriteLine("1 won, 2 finished: " + dict[2]);                     
                        return;                      
                    }
                    dict.AddOrUpdate(2, 1, (key, oldValue) => oldValue + 1);
                    System.Console.WriteLine("2: " + i);
                }
                c1.Cancel();
            }, c2.Token);

            t1.Start();
            t2.Start();
            Task.WaitAll(t1, t2);
        }
    }
}

/* Instructor solution: 

 class Program
    {
        static Task t1;
        static Task t2;
        static void Main(string[] args)
        {
            int loopConditionCount = 10;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task t1 = new Task(() =>
            {
                int max = 0;
                for (int i = 1; i <= loopConditionCount; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    else
                    {
                        Console.WriteLine($"Task One run number {i} ");
                        max = i;
                    }
                }
                Console.WriteLine();
                if (max == loopConditionCount)
                    Console.WriteLine("TASK ONE IS COMPLETE!");
                else
                {
                    Console.WriteLine("Task One is cancelled");
                    Console.WriteLine("Task One Maximum " + max);
                }
                cancellationTokenSource.Cancel();
            });

            t2 = new Task(() =>
            {
                int max = 0;
                for (int i = 1; i <= loopConditionCount; i++)
                {
                    if (token.IsCancellationRequested)
                        break;
                    else
                    {
                        Console.WriteLine($"Task Two run number {i} ");
                        max = i;
                    }
                }
                Console.WriteLine();
                if (max == loopConditionCount)
                    Console.WriteLine("TASK TWO IS COMPLETE!");
                else
                {
                    Console.WriteLine("Task Two is cancelled");
                    Console.WriteLine("Task Two Maximum " + max);
                }
                cancellationTokenSource.Cancel();
            });

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);
        }
    }





*/