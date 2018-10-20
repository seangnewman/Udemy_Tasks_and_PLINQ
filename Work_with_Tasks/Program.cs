using System;
using System.Threading;
using System.Threading.Tasks;

namespace Work_with_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {

            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello World!");
                //Console.WriteLine("Is background thread: {0}", Thread.CurrentThread.IsBackground);
                //Console.WriteLine("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);

                //throw new InvalidOperationException("Something went Ooops");

            }/*, TaskCreationOptions.LongRunning*/);


           
            task.Wait();
        }
    }
}
