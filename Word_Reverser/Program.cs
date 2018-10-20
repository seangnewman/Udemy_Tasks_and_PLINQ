using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Word_Reverser
{
    class Program
    {
        private static List<Task<string>> tasks = new List<Task<string>>();
        private static string ReverseString(string s)
        {
            Thread.Sleep(1000);
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length -1;   i >= 0; i--)
            {
                sb.Append(s[i]);
                
            }
            return sb.ToString();
        }

        public static void ProcessSentence(string sentence)
        {
            foreach (var word in sentence.Split())
            {
                tasks.Add(Task<string>.Factory.StartNew(() => ReverseString(word) + " ", TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning));
            }
        }
        static void Main(string[] args)
        {
            string sentence = "the quick brown fox jumped over the lazy dog";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task.Factory.StartNew(() => ProcessSentence(sentence)).Wait();

            sw.Stop();

            Console.WriteLine("Total runtime : {0} ms", sw.ElapsedMilliseconds);

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine("Task {0} complete : {1}", i, tasks[i].IsCompleted);
            }

            Console.Write("Result: ");
            foreach (var t in tasks)
            {
                Console.Write(t.Result);
            }

        }
    }
}
