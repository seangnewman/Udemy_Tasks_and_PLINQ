using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization_1
{
    class Program
    {
        public static int result;

        private static readonly object lockHandle = new object();

        public static EventWaitHandle readyForResult = new AutoResetEvent(false);
        public static EventWaitHandle setResult = new AutoResetEvent(false);

        public static void DoWork()
        {
            while (true)
            {
                int i = result;

                Thread.Sleep(1);

                readyForResult.WaitOne();

                lock (lockHandle)
                {
                    result = i + 1;
                }

                setResult.Set();                // Signal that data has completed
                
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(DoWork);
            t.Start();

            for (int i = 0; i < 100; i++)
            {

                readyForResult.Set();   // Ready to receive data

                setResult.WaitOne();    // Wait until Thread has result

                lock (lockHandle)
                {
                    Console.WriteLine(result);
                }

                // Simulate other work
                Thread.Sleep(10);
            }
        }
    }
}
