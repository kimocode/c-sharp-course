using System;

namespace MultiDimArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] items = new string[3, 3]
            {
               {"Item00","Item01","Item02"},
               {"Item10","Item11","Item12"},
               {"Item20","Item21","Item22"}
            };


            for (int rows = 0; rows < items.GetLength(0); rows++)
            {
                if (rows == 0)
                {
                    System.Console.Write("\t\t");
                    for (var columns = 0; columns < items.GetLength(1); columns++)
                    {
                        System.Console.Write("Column" + (columns + 1) + "\t");
                    }
                }
                System.Console.Write("\n");
                for (var columns = 0; columns < items.GetLength(1) ; columns++)
                {
                    
                    if (columns == 0)
                    {
                        System.Console.Write("Row " + (rows + 1) + "\t");
                    }
                    System.Console.Write(items[rows, columns]);
                }
            }
        }
    }
}
