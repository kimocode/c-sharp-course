using System;
using System.Threading;

namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(new ThreadStart(() => Console.WriteLine("Hello World!"))).Start();
            new Thread(new ThreadStart(() =>
            {
                for (var i = 0; i < 100; i++)
                {
                    System.Console.WriteLine("Mellow Orld");
                }
            })).Start();

            new Thread(new ThreadStart(delegate ()
            {
                for (var i = 0; i < 100; i++)
                {
                    System.Console.WriteLine("Yellow Orly");
                }
            })).Start();
        }
    }
}
