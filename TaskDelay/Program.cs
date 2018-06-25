using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            //比較  ContinueWith 
            //Continuation 作業完成後執行的方法
             Task<int> task = Task.Run(() =>
                                 Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));

            Task.Delay(2000).ContinueWith(c =>
           {
               int result = task.Result;
               Console.WriteLine(" ContinueWith 整除 3 的個數有：" + result);
           });
            Console.WriteLine("Task 執行中...");
            Console.ReadLine();

            // Delay
            Task.Delay(2000).GetAwaiter().OnCompleted(() =>
            {
                int result = task.Result;
                Console.WriteLine(" Delay 整除 3 的個數有：" + result);
            });
            Console.WriteLine("Task 執行中...");
            Console.ReadLine();
        }
    }
}
