using System;
using System.Diagnostics;

namespace ExtensionMethod
{
    class RunProfiling
    {
        public static void Run()
        {       
            DateTime dt = DateTime.Now;

            int loops = 5_000_000;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < loops; i++)
            {
                dt.FormatFormat();
            }
            watch.Stop();
            System.Console.WriteLine($"FormatFormat: {watch.ElapsedMilliseconds}");
            watch.Reset();
            watch.Start();
            for (var i = 0; i < loops; i++)
            {
                dt.FormatInterpolation();
            }
            watch.Stop();
            System.Console.WriteLine($"Format Interpollation: {watch.ElapsedMilliseconds}");
            watch.Reset();
            watch.Start();
            for (var i = 0; i < loops; i++)
            {
                dt.FormatConcat();
            }
            watch.Stop();
            System.Console.WriteLine($"Format Concat: {watch.ElapsedMilliseconds}");

            // Format: 2089
            // Format Interpollation: 1960
            // Format Concat: 1238
        }
    }
}
