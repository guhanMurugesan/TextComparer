using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextComparer.Logic;

namespace TextComparer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = @"D:\Design and Documents\Text comparer\01-SiteWide.txt";
            string file2 = @"D:\Design and Documents\Text comparer\01-SiteWide 2.txt";
            TextFileComparer comparer = new TextFileComparer();
            comparer.Process1(file1, file2);
        }
    }
}
