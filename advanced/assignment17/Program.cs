using System;

namespace assignment17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!".Upper());
        }


    }

    public static class Extensions
    {
        public static string Upper(this string input) 
        {
            return input.ToUpper();
        }
    }
}
