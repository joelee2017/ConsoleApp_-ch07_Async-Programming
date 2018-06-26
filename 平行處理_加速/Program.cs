using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 平行處理_加速
{
    class Program
    {
        static Stopwatch main_timer = new Stopwatch();
        static void Main(string[] args)
        {
            //平行處理 加速
            // 非同步作業的"加速" 可能只是附加效果
            // 某個需求進行一個費時 4 秒的網路要求，不管是同步作業或是非同步作業處理此要求，都是需要 4 秒來完成
            main_timer.Start();                
            for(int i = 0; i < 10; i++)
            {
                LongTimeWork1();
                LongTimeWork2();
            }
            main_timer.Stop();
            Console.WriteLine("工作 1 費時：{0} ms", w1_timer.ElapsedMilliseconds);
            Console.WriteLine("工作 2 費時：{0} ms", w2_timer.ElapsedMilliseconds);
            Console.WriteLine("總共費時：{0} ms", main_timer.ElapsedMilliseconds);

            Console.ReadLine();

        }

        static Stopwatch w1_timer = new Stopwatch();
        private static void LongTimeWork2()
        {
            w1_timer.Start();
            // Wait() 等待Task完成
            Task.Delay(300).Wait();
            w1_timer.Stop();
        }

        static Stopwatch w2_timer = new Stopwatch();
        private static void LongTimeWork1()
        {
            w2_timer.Start();
            // Wait() 等待Task完成
            Task.Delay(400).Wait();
            w2_timer.Stop();
        }
    }
}
