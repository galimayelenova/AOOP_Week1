using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace regex_defence
{
    class Program
    {
        static bool IsValid(string s)
        {
            return Regex.IsMatch(s, @"^Company Name: (.*) tel: \+[7]\s?\(?(\d{3})\)?[\s-]?(\d{3})-?(\d{4})$");
        }
        
        static void Main(string[] args)
        {
          //string input = "Company Name: Incoso, Inc. tel: +7 (555) 555-1212";
            StreamReader sr = File.OpenText(@"c:\asd\file.txt");
            while (!sr.EndOfStream)
            {
                string input = sr.ReadLine();

                if (IsValid(input))
                {
                    Match m = Regex.Match(input, @"^Company Name: (.*) tel: \+[7]\s?\(?(\d{3})\)?[\s-]?(\d{3})-?(\d{4})$");
                    Console.WriteLine("{0} +7 ({1}) {2}-{3}", m.Groups[1], m.Groups[2], m.Groups[3], m.Groups[4]);
                }
            }
           Console.ReadKey();

        }
    }
}

