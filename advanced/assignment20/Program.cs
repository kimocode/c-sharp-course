using System;
using System.Threading;

namespace assignment20
{
    class Program
    {
        static void Main(string[] args)
        {
            run(new Random().Next(1,100), "hi");
            run(new Random().Next(1,100), "ohayo gosaymasu");
            run(new Random().Next(1,100), "bonjour");
            run(new Random().Next(1,100), "hoi");
            run(new Random().Next(1,100), "godt morgn");
            run(new Random().Next(1,100), "hola");
            run(new Random().Next(1,100), "ciao");
            
        }

        private static void run(int n, string s)
        {
            new Thread(new ParameterizedThreadStart((object n) => {
                for(int i = 0; i < int.Parse(n.ToString()); i++) System.Console.WriteLine(s);
            })).Start(n);
        }
    }
}
