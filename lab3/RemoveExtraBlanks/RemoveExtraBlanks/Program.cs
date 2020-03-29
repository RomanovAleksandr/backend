using System;
using System.IO;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static string RemoveExtraBlanks(string line)
        {
            string newLine = "";
            bool blank = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ' && line[i] != '\t')
                {
                    newLine += line[i];
                    blank = true;
                }
                else if (blank)
                {
                    newLine += line[i];
                    blank = false;
                }
            }
            if (newLine.EndsWith(' ') || newLine.EndsWith('\t'))
            {
                newLine = newLine.Remove(newLine.Length - 1);
            }

            return newLine;
        }

        public static bool RemoveExtraBlanksInFile(string inputFileName, string outputFileName)
        {
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("File does not exist");
                return false;
            }

            StreamReader inputFile = new StreamReader(inputFileName);
            StreamWriter outputFile = new StreamWriter(outputFileName);

            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string newLine = RemoveExtraBlanks(line);
                Console.WriteLine(newLine);
                outputFile.WriteLine(newLine);
                
            }

            inputFile.Close();
            outputFile.Close();
            return true;
        }

        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage RemoveExtraBlanks.exe <inputFile> <outputFile>");
                return 1;
            }

            string inputFileName = args[0];
            string outputFileName = args[1];
            RemoveExtraBlanksInFile(inputFileName, outputFileName);

            return 0;
        }
    }
}
