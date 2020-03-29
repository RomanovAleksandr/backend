using System;

namespace RemoveExtraBlanks
{
    class Program
    {
        public static void RemoveExtraBlanks()
        {

        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage RemoveExtraBlanks.exe <inputFile> <outputFile>");
                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];


        }
    }
}
