using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 長時間作業執行緒
{
    class Program
    {
        static void Main(string[] args)
        {
            //利用 Thread 類別 Sleep 方法模擬長時間作業
            //建立新執行緒
            Thread t = new Thread(WritelTo50);
            //啟動執行緒
            t.Start();
            // 主執行緒暫停 1秒
            Thread.Sleep(1000);
            Write51To100();
            Console.ReadLine();
        }


        static void WritelTo50()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.Write(i + ",");
            }
        }


        static void Write51To100()
        {
            for (int i = 51; i <= 100; i++)
            {
                Console.Write(i + ",");
            }
        }
    }
}