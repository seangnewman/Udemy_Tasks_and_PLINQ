using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin_Challenge
{
    class Program
    {


        private static readonly List<Task<string>> tasks = new List<Task<string>>();
        private static string PigLatinString(string s)
        {
            const string append_ay = "ay"; 
            StringBuilder sb = new StringBuilder(s);

            sb.Remove(0, 1);
            sb.Append(s[0] + append_ay);

            return sb.ToString().ToLower();
        }

        private static string[] Map(string sentence)
        {
           
            return  sentence.Split();
        }

        public static string[] Process(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                int index = i;
                Task.Factory.StartNew(() => words[index] = PigLatinString(words[index]),
                    TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }
            return words;
        }

        public static string Reduce(string[] words)
        {
            return string.Join(" ", words);   
        }
        static void Main(string[] args)
        {

            //string sentence = "the quick brown fox jumped over the lazy dog";
            string sentence = "Sean Newman";

            if (string.IsNullOrEmpty(sentence))
            {
                Console.WriteLine("No Valid String Value has been set");
            }
            else
            {
                var task = Task<string[]>.Factory.StartNew(() => Map(sentence))
                        .ContinueWith<string[]>(t => Process(t.Result))
                            .ContinueWith<string>(t => Reduce(t.Result));

                Console.WriteLine("Result: {0}", task.Result);
            }
            

        }
    }
}
