using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Translator.Models
{
    public class Dictionary
    {
        StreamReader dictionary;
        public Dictionary(string path)
        {
            dictionary = new StreamReader(path);
        }

        public string findTranslation(string word)
        {
            word = word.ToLower();

            string line;
            while ((line = dictionary.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                if (words[0] == word)
                {
                    return words[1];
                }
                else if (words[1] == word)
                {
                    return words[0];
                }
            }

            return null;
        }
    }
}
