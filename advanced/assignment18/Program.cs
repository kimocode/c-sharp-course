using System;

namespace assignment18
{
    class Program
    {
        private delegate void DoMath(int op1, int op2);
        static void Main(string[] args)
        {
            DoMath doMath = Add;
            doMath += Subs;
            doMath += Mult;
            doMath += Div;
            doMath += Mod;
            // System.Console.WriteLine(doMath(3,5));

            doMath(3,5);
        }

        private static void Add(int op1, int op2) => System.Console.WriteLine(  op1 + op2); 
        private static void Subs(int op1, int op2) =>  System.Console.WriteLine(  op1 - op2); 
        private static void Mult(int op1, int op2) =>  System.Console.WriteLine(  op1 * op2); 
        private static void Div(int op1, int op2) =>  System.Console.WriteLine(  op1 / op2); 
        private static void Mod(int op1, int op2) =>  System.Console.WriteLine(  op1 % op2); 
    }
}
 