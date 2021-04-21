using System;
using System.Diagnostics;

namespace notepad
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Process.Start("notepad.exe", "test.txt");
            
        }
    }
}
