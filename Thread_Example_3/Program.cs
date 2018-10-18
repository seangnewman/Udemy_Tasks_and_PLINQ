using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Example_3
{
    class MainClass
    {

        private const int REPETITIONS = 1000;


        static void Main(string[] args)
        {
            Thread t = new Thread((x) =>
            {
                Console.WriteLine("Thread has started, press ENTER to continue....");
                Console.ReadLine();
            });

            t.IsBackground = true;
            t.Start();
        }
    }
}