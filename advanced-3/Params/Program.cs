using System;

namespace Params
{
    /// <summary>
    /// Params & Generics exercise
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PrintAnyNumberOfAnything("la","di","da");
            PrintAnyNumberOfAnything(1,2);
            PrintAnyNumberOfAnything(0.75,8,9,9,9);
            PrintAnyNumberOfAnything('o','k');
            PrintAnyNumberOfAnything(new object(), new object());
        }

        private static void PrintAnyNumberOfAnything<T>(params T[] items) 
        {
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
