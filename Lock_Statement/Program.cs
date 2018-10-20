using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock_Statement
{
    class Program
    {
        private static readonly int value1 = 1;
        private static int value2 = 1;


        // Only purpose is to serve as synchronization object
        private static readonly object syncObj = new object();

        private static void DoWork()
        {
            lock (syncObj)      // Code is now Thread safe
            {
                if (value2 > 0)
                {
                    Console.WriteLine(value1 / value2);
                    value2 = 0;
                }

            }
          
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(x => { DoWork(); });
            Thread t2 = new Thread(x => { DoWork(); });

            t1.Start();
            t2.Start();
        }
    }
}
