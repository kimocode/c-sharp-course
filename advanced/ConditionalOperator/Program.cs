using System;

namespace ConditionalOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine()) ;
            System.Console.WriteLine(number % 2 == 0 ? "Even" : "Odd");    
        }
    }
}
