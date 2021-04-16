using System;
using System.Diagnostics;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {       
            DateTime dt = DateTime.Now;
            System.Console.WriteLine(dt.Format());
            if(args.Length > 0 && args[0].Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase)) RunProfiling.Run();  
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
