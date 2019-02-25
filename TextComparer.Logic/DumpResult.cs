using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparer.Logic
{
    public class DumpResult
    {
        public static string Header = "----------------------------*{0}*-----------------------------------------";
        public static string AddedTitle = "Added Settings";
        public static string RemovedTitle = "Removed Settings";
        public static string ChangedTitle = "Changed Settings";
        public static string SettingText = "{0}={1} [LineNumber={2}]";

        public DumpResult()
        {

        }

        public static void Process(IList<KeyValuePair<string, string>> addedT, IList<KeyValuePair<string, string>> removedT, IList<KeyValuePair<string, string>> changedT)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter writer = new StreamWriter(Path.Combine(docPath, "comparedSettingsResult.txt"), true))
            {
                WriteTextMap(addedT,AddedTitle,writer);
                WriteTextMap(removedT, RemovedTitle, writer);
                WriteTextMap(changedT, ChangedTitle, writer);
            }
        }

        public static void Process(IList<SettingInfo> addedT, IList<SettingInfo> removedT, IList<SettingInfo> changedT)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string combinedPath = Path.Combine(docPath, "comparedSettingsResult.txt");
            
            if(File.Exists(combinedPath))
                File.WriteAllText(combinedPath, string.Empty);
            using (StreamWriter writer = new StreamWriter(combinedPath, true))
            {
                WriteTextMap(addedT, AddedTitle, writer);
                WriteTextMap(removedT, RemovedTitle, writer);
                WriteTextMap(changedT, ChangedTitle, writer);
            }
        }

        private static void WriteTextMap(IList<SettingInfo> textMap, string header, StreamWriter outputFile)
        {
            outputFile.WriteLine(Header, header);

            if (!textMap.Any())
            {
                outputFile.WriteLine("No changes");
                return;
            }

            foreach (var item in textMap)
                outputFile.WriteLine(SettingText, item.Key, item.Value,item.LineNumber);
        }

        private static void WriteTextMap(IList<KeyValuePair<string,string>> textMap, string header, StreamWriter outputFile)
        {
            outputFile.WriteLine(Header, header);

            if (!textMap.Any())
            {
                outputFile.WriteLine("No changes");
                return;
            }

            foreach (var item in textMap)
                outputFile.WriteLine(SettingText, item.Key, item.Value);
        }
    }
}
