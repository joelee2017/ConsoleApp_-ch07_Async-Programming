using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 平行處理_加速改成_async_與__await_的非同步方式
{
    class Program
    {
        static Stopwatch main_timer = new Stopwatch();
        static void Main(string[] args)
        {
            //平行處理_加速改成_async_與__await_的非同步方式
            main_timer.Start();
            DoWork().Wait();

            Console.WriteLine("工作 1 費時：{0} ms", w1_timer.ElapsedMilliseconds);
            Console.WriteLine("工作 2 費時：{0} ms", w2_timer.ElapsedMilliseconds);
            Console.WriteLine("總共費時：{0} ms", main_timer.ElapsedMilliseconds);

            Console.ReadLine();
        }


        static Stopwatch w1_timer = new Stopwatch();
        static  void LongTimeWork1()
        {
            w1_timer.Start();
            // Wait() 等待Task完成
            Task.Delay(300).Wait();
            w1_timer.Stop();
        }

        static Stopwatch w2_timer = new Stopwatch();
        static async Task LongTimeWork2()
        {
            w2_timer.Start();
            // Wait() 等待Task完成
            await Task.Delay(400);
            w2_timer.Stop();
        }


        static async Task DoWork()
        {
            Task result = null;
            for(int i = 0; i < 10; i++)
            {
                LongTimeWork1();
                if(result != null )
                {
                    await result;
                }
                result = LongTimeWork2();
            }
            await result;
        }
    }
}
