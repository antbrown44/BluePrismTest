using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BluePrismTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string startWord = "";
            string endWord = "";

            if (args.Length == 2)
            {
                startWord = args[0];
                endWord = args[1];
            }
            else
            {
                Console.Write(i18n.StartWord);
                startWord = Console.ReadLine();
                Console.Write(i18n.EndWord);
                endWord = Console.ReadLine();
            }

            WordEnumerator enumerator = new WordEnumerator(startWord.ToLower(), endWord.ToLower(), "", "");
            List<string> results = enumerator.GetAllWordsFromDictionary();

            if (results.Any())
            {
                enumerator.WriteResults(results);
            }
            else Console.WriteLine(i18n.NoResults);

            Console.WriteLine(i18n.ProcessEnd);
            Console.ReadLine();
        }
    }
}
