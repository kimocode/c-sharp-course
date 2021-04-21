using System;
using System.Diagnostics;

namespace NotepadExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.File.WriteAllText(@"test.txt", "Ladieda");
            Process.Start("notepad.exe","test.txt");
        }
    }
}
