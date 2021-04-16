using System;
using System.IO;

namespace RecursiveMethods
{
    
    /// <summary>
    /// Exercise for recursive methods
    /// Variation: list files & directories
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            ListCurrentDirectoryTree(Directory.GetCurrentDirectory());
        }

        public static void ListCurrentDirectoryTree(string path, int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)} {path} - Created on: {File.GetCreationTimeUtc(path)}");
     
            FileAttributes attr = File.GetAttributes(path);

            if((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                string [] files = Directory.GetFileSystemEntries(path);
                foreach (var item in files)
                {
                    ListCurrentDirectoryTree(item, indent + 1);
                }
            }            
        }
    }
}
