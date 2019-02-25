using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextComparer.Logic
{
    interface IChangeComparer<T>
    {
        bool IsChanged(T object1, T object2);
    }

    public class SettingInfo : IChangeComparer<SettingInfo>,IEqualityComparer<SettingInfo>
    {
        public SettingInfo(string key,string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public SettingInfo()
        {

        }

        public string Key { get; set; }

        public string Value { get; set; }

        public int LineNumber { get; set; }


        public bool IsChanged(SettingInfo object1, SettingInfo object2)
        {
            if (object1 != null && object2 != null)
            {
                if (object1.Key == object1.Key && object1.Value != object1.Value);
                return true;
            }
            return false;
        }

        public bool Equals(SettingInfo x, SettingInfo y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            if ((x.Key == y.Key) && (y.Value == x.Value))
                return true;
            return false;
        }

        public int GetHashCode(SettingInfo obj)
        {
            string value = obj.Key + obj.Value;
            return value.GetHashCode();
        }
    }

    public class ChangeComparer : IEqualityComparer<SettingInfo>
    {
        public ChangeComparer()
        {

        }
        public bool Equals(SettingInfo x, SettingInfo y)
        {
            if (x == null && y == null)
                return false;
            if (x == null || y == null)
                return false;
            if ((x.Key == y.Key) && (y.Value != x.Value))
                return true;
            return false;
        }

        public int GetHashCode(SettingInfo obj)
        {
            string value = obj.Key;
            return value.GetHashCode();
        }
    }
}
