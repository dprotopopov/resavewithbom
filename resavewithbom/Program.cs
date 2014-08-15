using System;
using System.IO;
using System.Text;

namespace resavewithbom
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string dir = ".";
            string mask = "*.txt";

            for (int i = 0; i < args.Length; i++)
            {
                if (string.CompareOrdinal(args[i], "-d") == 0)
                {
                    dir = args[++i];
                }
                else
                {
                    mask = args[i];
                }
            }
            foreach (FileInfo f in new DirectoryInfo(dir).GetFiles(mask, SearchOption.AllDirectories))
            {
                Console.WriteLine(f.FullName);
                string s = File.ReadAllText(f.FullName, Encoding.Default);
                File.WriteAllText(f.FullName, s, Encoding.UTF8);
            }
        }
    }
}