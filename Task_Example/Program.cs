using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //start Task
            var task = Task<string>.Factory.StartNew(() =>
           {
               Thread.Sleep(2000);
               return "Sean";
           });

            Console.Write("Your name is ");
            Console.WriteLine(task.Result);
        }
    }
}
