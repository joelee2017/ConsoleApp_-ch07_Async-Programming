using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多執行緒的啟動
{
    class Program
    {
        static void Main(string[] args)
        {
            //執行線並不會按照順序
            //for( int i =0; i < 10; i++)
            //{
            //    Thread t = new Thread(() => {
            //        Console.WriteLine(string.Format("{0} : {1}",
            //                        Thread.CurrentThread.Name, i));
            //    });
            //    t.Name = string.Format("執行緒{0}", i);
            //    t.IsBackground = true;
            //    t.Start();
            //}
            //Console.ReadLine();


            //重構
            for(int i = 0; i < 10; i++)
            {
                NewThread1To10(i);
            }
            Console.ReadLine();
        }

        //由於是在 for  迴圈內部變成同步程式碼，所以能正確執行
        private static void NewThread1To10(int i)
        {
            Thread t = new Thread(() => 
            {
                Console.WriteLine(string.Format("{0} : {1}",
                                    Thread.CurrentThread.Name, i));
            });
            t.Name = string.Format("執行緒 {0}", i);
            t.IsBackground = true;
            t.Start();
        }
    }
}
