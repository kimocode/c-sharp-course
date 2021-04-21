using System;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
           string [,][,] numbers = new string[2,3][,];

           for (var i = 0; i < numbers.GetLength(0); i++)
           {
               for (var j = 0; j < numbers.GetLength(1); j++)
               {
                   numbers[i,j] = new string [4,5];
                   for (var k = 0; k < 4; k++)
                   {

                       for (var l = 0; l < 5; l++)
                       {
                            numbers[i,j][k,l] = $"{i}-{j}-{k}-{l}";
                            System.Console.WriteLine(numbers[i,j][k,l]);                          
                       }
                   }
               }
           }
        }
    }
}
