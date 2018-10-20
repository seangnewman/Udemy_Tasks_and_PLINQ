using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock_Statement_2
{
    class Program
    {
        private static readonly int value1 = 1;
        private static int value2 = 1;


        // Only purpose is to serve as synchronization object
        private static readonly object syncObj = new object();

        private static void DoWork()
        {
            bool lockTaken = false;

            try
            {
                Monitor.TryEnter(syncObj, TimeSpan.FromMilliseconds(50), ref lockTaken);
                if(value2 > 0)
                {
                    Console.WriteLine(value1/value2);
                    value2 = 0;
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(syncObj);
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
 
