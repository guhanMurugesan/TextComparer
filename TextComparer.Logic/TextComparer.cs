using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparer.Logic
{
    public class TextFileComparer
    {
        public TextFileComparer()
        {

        }

        public void Process(string file1,string file2)
        {
            var textMap1 = TextParser.GetKeyValueCollection(file1).OrderBy(x=>x.Key).ToList();
            var textMap2 = TextParser.GetKeyValueCollection(file2).OrderBy(x=>x.Value).ToList();

            var removedTextMap = textMap1.Except(textMap2).ToList();
            var addedTextMap = textMap2.Except(textMap1).ToList();

            var changedTextMap = removedTextMap.Where(x => addedTextMap.Where(y => y.Key == x.Key).Any()).ToList();

            DumpResult.Process(addedTextMap.Except(changedTextMap).ToList(),removedTextMap.Except(changedTextMap).ToList(),changedTextMap);
        }

        public void Process1(string file1, string file2)
        {
            IEqualityComparer<SettingInfo> comparer = new SettingInfo();
            var textMap1 = TextParser.GetSettingInfoCollection(file1).OrderBy(x => x.Key).ThenBy(x=>x.LineNumber).ToList();
            var textMap2 = TextParser.GetSettingInfoCollection(file2).OrderBy(x => x.Value).ThenBy(x=>x.LineNumber).ToList();

            var removedTextMap = textMap1.Except(textMap2, comparer).ToList();
            var addedTextMap = textMap2.Except(textMap1, comparer).ToList();

            var changedTextMap = removedTextMap.Where(x => addedTextMap.Where(y => y.Key == x.Key).Any()).ToList();

            DumpResult.Process(addedTextMap.Where(x=> !changedTextMap.Where(y=>x.Key == y.Key).Any()).ToList(),
                                removedTextMap.Where(x => !changedTextMap.Where(y => x.Key == y.Key).Any()).ToList(), changedTextMap);
        }

        

        
    }
}
