using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparer.Logic
{
    public static class Helper
    {
        public static KeyValuePair<string,string> GetKeyValueString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new KeyValuePair<string,string>(string.Empty,string.Empty);
            var iEQ = text.IndexOf('=');
            return new KeyValuePair<string,string>(text.Substring(0, iEQ),text.Substring(iEQ+1, text.Length - (iEQ+1)));
        }

        public static SettingInfo GetSettingInfo(string text)
        {
            if(string.IsNullOrEmpty(text))
                return null;
            var iEQ = text.IndexOf('=');
            return new SettingInfo(text.Substring(0, iEQ), text.Substring(iEQ + 1, text.Length - (iEQ + 1)));
        }
    }
}
