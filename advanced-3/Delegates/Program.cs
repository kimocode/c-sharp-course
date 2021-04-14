using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        public  delegate void PrintDictionary(Dictionary<int,string> d); 
        static void Main(string[] args)
        {
            PrintDictionary dict = new PrintDictionary(Print);

            dict(new Dictionary<int, string>(){
                {1,"a"},
                {2,"b"},
                {3,"h"},
                {4,"g"},
                {5,"F"}
            });
        }

        private static void Print(Dictionary<int, string> d) 
        {
            foreach (var item in d)
            {
                System.Console.WriteLine(item.Key
                    + " - "
                    + item.Value);
            }
        }
    }
}
