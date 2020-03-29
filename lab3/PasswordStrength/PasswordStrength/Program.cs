using System;
using System.Linq;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class Program
    {
        public static bool IsUpperCase(char ch)
        {
            return 'A' <= ch && ch <= 'Z';
        }

        public static bool IsLowerCase(char ch)
        {
            return 'a' <= ch && ch <= 'z';
        }

        public static int StrengthByLength(string pass)
        {
            return pass.Length * 4;
        }

        public static int StrengthByDigitsCount(string pass)
        {
            return pass.Count(char.IsDigit) * 4;
        }

        public static int StrengthByUpperCharsCount(string pass)
        {
            return (pass.Length - pass.Count(IsUpperCase)) * 2;
        }

        public static int StrengthByLowerCharsCount(string pass)
        {
            return (pass.Length - pass.Count(IsLowerCase)) * 2;
        }

        public static int StrengthIfOnlyChar(string pass)
        {
            if (pass.Length == pass.Count(char.IsLetter))
            {
                return -pass.Length;
            }
            return 0;
        }

        public static int StrengthIfOnlyDigits(string pass)
        {
            if (pass.Length == pass.Count(char.IsDigit))
            {
                return -pass.Length;
            }
            return 0;
        }

        public static int StrengthByRepeatedChars(string pass)
        {
            int strength = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < pass.Length; i++)
            {
                if (dict.ContainsKey(pass[i]))
                {
                    dict[pass[i]] += 1; 
                }
                else
                {
                    dict[pass[i]] = 1;
                }
            }
            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    strength -= item.Value;
                }
            }

            return strength;
        }

        public static int CalcPasswordStrength(string pass)
        {
            int passwordStrength = 0;
            passwordStrength += StrengthByLength(pass);
            passwordStrength += StrengthByDigitsCount(pass);
            passwordStrength += StrengthByUpperCharsCount(pass);
            passwordStrength += StrengthByLowerCharsCount(pass);
            passwordStrength += StrengthIfOnlyChar(pass);
            passwordStrength += StrengthIfOnlyDigits(pass);
            passwordStrength += StrengthByRepeatedChars(pass);
            return passwordStrength;
        }

        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage PasswordStrength.exe <password>");
                return 1;
            }

            string password = args[0];
            int passwordStrength = CalcPasswordStrength(password);
            Console.WriteLine(passwordStrength);

            return 0;
        }
    }
}
