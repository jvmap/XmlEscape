using System;
using System.IO;

namespace XmlEscape
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
                PrintUsage();
            else if (args[0] == "--help" || args[0] == "-?")
                PrintUsage();
            else
            {
                string path = args[0];
                using Stream input =
                    File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlEscaper.Escape(input, Console.Out);
            }
        }

        static void PrintUsage()
        {
            string cmd = Environment.GetCommandLineArgs()[0];
            Console.WriteLine($"Usage: {cmd} <fileName>");
            Console.WriteLine("Prints escaped XML to stdout.");
        }
    }
}
