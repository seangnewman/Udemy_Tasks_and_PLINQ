using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Example_2
{
    class MainClass
    {

        private const int REPETITIONS = 1000;

        public static void DoWork()
        {
            for (int i = 0; i < REPETITIONS; i++)
            {
                Console.Write("B");
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                Thread t = new Thread((x) => { DoWork(); } );
                t.Name = "Thread" + i.ToString();
                t.Start();
            }

            int dummy = 123;
        }
    }
}
