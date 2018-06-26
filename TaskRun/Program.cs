using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRun
{
    class Program
    {
        // public static Task Run(
        //     Action action
        //)

        static void Main(string[] args)
        {
            //Task.Run(() => Console.WriteLine("From Task."));
            //Console.ReadLine();

            ////===================================================================
            //Task task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("From Task.");
            //});
            //// 因為 Task 被 Thread.Sleep 暫停，回應 false
            //Console.WriteLine(task.IsCompleted);
            //// 封鎖執行緒，等待 Task 完成
            //task.Wait();
            //// Task 已完成，回應 True
            //Console.WriteLine(task.IsCompleted);
            //Console.ReadLine();
            ////===================================================================

            //Task<int> task = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Form Task.");
            //    return 1;
            //});            

            ////如果 Task 未完成，封鎖執行緒
            //int result = task.Result;
            //Console.WriteLine(result);
            //Console.ReadLine();
            ////====================================================================

            //1~5000000 被 3 整除的有幾個
            //Task<int> task = Task.Run(() =>
            //    Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));
            //Console.WriteLine("Task 執行中.......");
            //Console.WriteLine("整除 3 的個數有：" + task.Result);
            //Console.ReadLine();
            ////===================================================================

            ////Continuation 作業完成後執行的方法
            // Task<int> task = Task.Run(() =>
            //                     Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));
            // task.ContinueWith(c =>
            //{
            //    int result = task.Result;
            //    Console.WriteLine("整除 3 的個數有：" + result);
            //});
            // Console.WriteLine("Task 執行中...");
            // Console.ReadLine();
            ////=====================================================================


            //// awaiter C# 5.0 非同步功能使用這種方式
            //Task<int> task = Task.Run(
            //    () => Enumerable.Range(1, 500000).Count(n => (n % 3) == 0));
            //var awaiter = task.GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    int result = awaiter.GetResult();
            //    Console.WriteLine("整除 3 的個數有：" + result);
            //});
            //Console.WriteLine("Task 執行中...");
            //Console.ReadLine();
        }
    }
}
