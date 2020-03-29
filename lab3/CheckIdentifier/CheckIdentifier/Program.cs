using System;

namespace CheckIdentifier
{
    public class Program
    {
        private static bool IsLetter(char ch)
        {
            return ('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z');
        }

        public static bool Check(string identifier)
        {
            if (identifier.Length == 0)
            {
                Console.WriteLine("No");
                Console.WriteLine("An empty string was passed");
                return false;
            }
            if (!IsLetter(identifier[0]))
            {
                Console.WriteLine("No");
                Console.WriteLine("The identifier must begin with a letter");
                return false;
            }
            for (int i = 1; i < identifier.Length; i++)
            {
                if (!IsLetter(identifier[i]) && !char.IsDigit(identifier[i]))
                {
                    Console.WriteLine("No");
                    Console.WriteLine("The identifier must contain only digits or letters.");
                    return false;
                }
            }
            Console.WriteLine("Yes");
            return true;
        }

        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage: CheckIdentifier.exe <identifier>");
                return 1;
            }
            string identifier = args[0];
            Check(identifier);
            return 0;
        }
    }
}
