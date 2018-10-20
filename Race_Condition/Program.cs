using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race_Condition
{
    class Program
    {

        public static int i;

        public static void DoWork()
        {
            for (i = 0; i < 5; i++)
            {
                Console.Write("*");
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(x => { DoWork(); });
            t.Start();

            DoWork();


        }
    }
}
