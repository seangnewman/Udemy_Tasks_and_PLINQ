using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ_word_reverser
{
    class Program
    {
        static void Main(string[] args)
        {

            string sentence = "The quick brown fox jumped over the lazy dog";

            var words = sentence.Split()
                .AsParallel().AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Select(word => new string(word.Reverse().ToArray()));

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
