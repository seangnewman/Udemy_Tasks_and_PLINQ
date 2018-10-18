using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Example_1
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
            //Thread t1 = new Thread(new ThreadStart(DoWork));
            //t1.Start();

            //Thread t2 = new Thread(DoWork);
            //t2.Start();

            Thread t3 = new Thread(x => { DoWork(); } );
            t3.Start();

            for (int i = 0; i < REPETITIONS; i++)
            {
                Console.Write("A");
            }
           
        }
    }
}
