﻿using System;
using System.Diagnostics;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {       
            DateTime dt = DateTime.Now;
            System.Console.WriteLine(dt.Format());

            int loops = 5000_000;
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

    public static class Extensions
    {
        public static string Format(this DateTime date)
        {
            return FormatConcat(date);
        }

        public static string FormatFormat(this DateTime date)
        {
            return string.Format("{0:dddd dd MMMM yyyy}", date);
        }

        public static string FormatInterpolation(this DateTime date)
        {
            return $"{date.DayOfWeek} {date.Day} {date.Month} {date.Year}";
        }

        public static string FormatConcat(this DateTime date)
        {
            return date.DayOfWeek + " " + date.Day  + " " + date.Month + " " + date.Year;
        }
    }
}
