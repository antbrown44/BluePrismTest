using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BluePrismTests
{
    [TestClass]
    public class EnumeratorTests
    {
        [TestMethod]
        public void ItShouldFindAMatchWhichIsGreaterGivenTwoWords()
        {
            //A
            string startWord = "Spot";
            string endWord = "Spin";

            //A
            var result = string.Compare(startWord, endWord);

            //A
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void ItShouldFindAMatchWhichIsSmallerGivenTwoWords()
        {
            //A
            string startWord = "down";
            string endWord = "revs";

            //A
            var result = string.Compare(startWord, endWord);

            //A
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ItShouldFindIntermediateWordsInListGivenStartAndEndWord()
        {
            //A
            List<string> MockList = new List<string>() { "dirt,", "Spin", "Spud", "stew", "Spit", "Tint", "hand", "Revs", "wave" };
            List<string> ExpectedList = new List<string>() { "Spud", "stew", "Spit" };
            string startWord = "Spin";
            string endWord = "Tint";

            //A
            var resultList = new List<string>();
            foreach (var word in MockList)
            {
                if (string.Compare(word, startWord) == 1)
                {

                    if (string.Compare(word, endWord) == -1)
                    {
                         resultList.Add(word);
                    }
                }
            }

            //A
            CollectionAssert.AreEquivalent(resultList, ExpectedList);
            Assert.AreEqual(resultList.Count, 3);
        }


        [TestMethod]
        public void ItShouldReturnEmptyListWhenNoMatchesFound()
        {
            //A
            List<string> MockList = new List<string>() { "dirt,", "Spin", "Spud", "stew", "Spun", "Tint", "hand", "Revs", "wave" };
            List<string> ExpectedList = new List<string>();
            string startWord = "Spin";
            string endWord = "Spot";

            //A
            var resultList = new List<string>();
            foreach (var word in MockList)
            {
                if (string.Compare(word, startWord) == 1)
                {

                    if (string.Compare(word, endWord) == -1)
                    {
                        resultList.Add(word);
                    }
                }

            }

            //A
            CollectionAssert.AreEquivalent(resultList, ExpectedList);
            Assert.AreEqual(resultList.Count, 0);
        }
    }
}
