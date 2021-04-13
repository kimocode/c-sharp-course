﻿using System;
using System.IO;

namespace RecursiveMethods
{
    
    /// <summary>
    /// Exercise for recursive methods
    /// Variation: list files & directories
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            new Program().ListCurrentDirectoryTree(Directory.GetCurrentDirectory());
        }

        private void ListCurrentDirectoryTree(string path, int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)} {path}");
     
            FileAttributes attr = File.GetAttributes(path);

            if((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                string [] files = Directory.GetFileSystemEntries(path);
                foreach (var item in files)
                {
                    this.ListCurrentDirectoryTree(item, indent + 1);
                }
            }            
        }
    }
}