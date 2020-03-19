using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string input = args[0];
                input = new string(input.Distinct().ToArray());
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage remove_duplicates.exe <input string>");
            }
        }
    }
}
