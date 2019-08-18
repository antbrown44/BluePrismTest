using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace BluePrismTechTest
{
    public class WordEnumerator : IDictionary
    {
        private string StartWord { get; set; }
        private string EndWord { get; set; }
        public string DictionaryFile { get; set; }
        public string ResultFile { get; set; }
        public List<string> DictionaryList { get; set; }

        public WordEnumerator(string startWord, string endWord, string dictionaryFile, string resultFile)
        {
            StartWord = startWord;
            EndWord = endWord;
            DictionaryFile = dictionaryFile != "" ? dictionaryFile : ConfigurationManager.AppSettings["DictionaryFile"];
            ResultFile = resultFile != "" ? resultFile : ConfigurationManager.AppSettings["ResultFile"];
            ReadDictionaryFile();
        }

        /// <summary>
        /// check if start word exists in dictionary and only then perform a search for intermediate words
        /// </summary>
        /// <returns>list of itermediate words between start and end word</returns>
        public List<string> GetAllWordsFromDictionary()
        {
            if (DictionaryList.Contains((StartWord)))
            {
                return SearchDictionary(DictionaryList);
            }
            return new List<string>();
        }

        /// <summary>
        /// write out results list to path/file specified
        /// </summary>
        /// <param name="resultList"></param>
        public void WriteResults(List<string> resultList)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ResultFile))
                {
                    resultList.ForEach(r => writer.WriteLine(r));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// search dictionary list for intermediate words
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns>list of results found in dictionary</returns>
        public List<string> SearchDictionary(List<string> dataList)
        {
            var resultsList = new List<string>() { StartWord, EndWord };
            foreach (var word in dataList)
            {
                if (CompareWord(StartWord, word) == 1)
                {

                    if (CompareWord(EndWord, word) == -1)
                    {
                        if(!resultsList.Contains(word)) resultsList.Add(word);
                    }
                }
            }
            resultsList.Sort();
            return resultsList;
        }

        /// <summary>
        /// If both strings are equal, return 0. If first string is greater than second string, return 1 else return -1.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="wordToCompare"></param>
        /// <returns>int</returns>
        private static int CompareWord(string word, string wordToCompare)
        {
            return string.Compare(wordToCompare, word, true);
        }

        /// <summary>
        /// read the dictionary file from path specified
        /// </summary>
        public void ReadDictionaryFile()
        {
            DictionaryList = new List<string>();
            try
            {
                using (var sr = new StreamReader(DictionaryFile, true))
                {
                    while (sr.Peek() >= 0)
                    {
                        string word = sr.ReadLine();
                        if (word.Length == 4) DictionaryList.Add(word.ToLower());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
