using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparer.Logic
{
    public class TextParser
    {
        public TextParser()
        {

        }

        public static IDictionary<string,string> GetKeyValueCollection(string fileName)
        {
            IDictionary<string, string> textMap = new Dictionary<string,string>();
            if(File.Exists(fileName))
            {
                using(StreamReader sr = File.OpenText(fileName))
                {
                    string textLine;
                    while ((textLine = sr.ReadLine()) != null)
	                {
                        textLine = textLine.Trim();
                        if (!string.IsNullOrEmpty(textLine) && !textLine.StartsWith("#"))
                        {
                            var keyValue = Helper.GetKeyValueString(textLine);
                            if (!textMap.Any(x => x.Key.Equals(keyValue.Key)))
                                textMap.Add(keyValue);
                        }
	                }
                }
            }

            return textMap;
        }


        public static IList<SettingInfo> GetSettingInfoCollection(string fileName)
        {
            int LineNumber = 1;
            IList<SettingInfo> textMap = new List<SettingInfo>();
            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string textLine;
                    while ((textLine = sr.ReadLine()) != null)
                    {
                        textLine = textLine.Trim();
                        if (!string.IsNullOrEmpty(textLine) && !textLine.StartsWith("#"))
                        {
                            var settingInfo = Helper.GetSettingInfo(textLine);
                            settingInfo.LineNumber = LineNumber;
                            if (!textMap.Any(x => x.Key.Equals(settingInfo.Key)))
                                textMap.Add(settingInfo);
                        }
                        LineNumber++;
                    }
                }
            }

            return textMap;
        }


    }
}
