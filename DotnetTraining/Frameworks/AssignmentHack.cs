using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkExamples
{
    class StringEncoder
    {
        const string CODE = "the quick and brown fox jumps over the lazy dog";
        static List<string> words = CODE.Split(' ').ToList();
        public static string Encode(string input)
        {
            if (input == null) throw new NullReferenceException("Arg cannot be null");
            if (string.IsNullOrEmpty(input)) throw new ArgumentException("Arg cannot be empty");

            var content = string.Empty;

            foreach (char c in input.ToLower())
            {
                if (c == ' ')
                {
                    content = content.Substring(0, content.Length - 1);
                    content += getCode(c);
                }
                else
                {
                    content += getCode(c);
                    content += ',';
                }
            }
            return content.Substring(0, content.Length - 1);

        }

        public static string getCode(char ch)
        {
            if (ch == ' ') return "-";
            string code = string.Empty;
            foreach (var word in words)
            {
                if (word.Contains(ch))
                {
                    code += words.IndexOf(word);
                    code += word.IndexOf(ch);
                    return code;
                }
            }
            return code;
        }
    }

    class UniqueAndDuplicate
    {
        public static Dictionary<string, List<string>> GetDuplicatesAndUnique(string input)
        {
            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
            pairs["Unique"] = new List<string>();
            pairs["Duplicates"] = new List<string>();
            foreach(var word in input.ToLower().Split(" "))
            {
                if (pairs["Unique"].Contains(word))
                {
                    if(!pairs["Duplicates"].Contains(word))
                        pairs["Duplicates"].Add(word);
                    pairs["Unique"].Remove(word);
                }
                else
                {
                    pairs["Unique"].Add(word); 
                }
            }
            return pairs;
        }
    }
    internal class AssignmentHack
    {
        static void Main(string[] args)
        {
            //testForBangalore();
            //testForMindtree();
            //testForGlobalVillage();
            testForUniqueValues();
        }

        private static void testForUniqueValues()
        {
            var actual = UniqueAndDuplicate.GetDuplicatesAndUnique("Do not call me let me call you");
            var unique = new List<string> { "Do", "let", "not", "you" };
            var duplicates = new List<string> { "call", "me" };

            var expected = new Dictionary<string, List<string>>();
            expected.Add("Unique", unique);
            expected.Add("Duplicates", duplicates);
            var uniques = actual["Unique"];
            Console.Write("Unique: ");
            foreach (var item in uniques)
            {                
                Console.Write(item + " ");
            }
            Console.WriteLine();
            var dupes = actual["Duplicates"];
            Console.Write("Duplicates: ");
            foreach (var e in dupes)
            {
                Console.Write(e + " ");
            }

        }

        private static void testForGlobalVillage()
        {
            var actual = StringEncoder.Encode("Global Village");
            var expected = "92,80,32,30,20,80-61,12,80,80,20,92,02";
            if (actual == expected)
            {
                Console.WriteLine("Tests have passed");
            }
            else
            {
                Console.WriteLine("Tests have failed");
            }
        }

        private static void testForMindtree()
        {
            var actual = StringEncoder.Encode("mindtree");
            var expected = "52,12,21,22,00,31,02,02";
            if (actual == expected)
            {
                Console.WriteLine("Tests have passed");
            }
            else
            {
                Console.WriteLine("Tests have failed");
            }
        }

        private static void testForBangalore()
        {
            var actual = StringEncoder.Encode("bangalore");
            var expected = "30,20,21,92,20,80,32,31,02";
            if (actual == expected)
            {
                Console.WriteLine("Tests have passed");
            }
            else
            {
                Console.WriteLine("Tests have failed");
            }
        }
    }
}
