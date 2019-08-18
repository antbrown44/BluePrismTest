using System.Collections.Generic;

namespace BluePrismTechTest
{
    public interface IDictionary
    {
        string DictionaryFile { get; set; }
        string ResultFile { get; set; }
        List<string> DictionaryList { get; set; }

        List<string> SearchDictionary(List<string> file);
        void WriteResults(List<string> resultList);
        void ReadDictionaryFile();
    }
}
