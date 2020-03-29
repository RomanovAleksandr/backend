using System;

namespace PasswordStrength
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage PasswordStrength.exe <password>");
                return 1;
            }
            return 0;
        }
    }
}
