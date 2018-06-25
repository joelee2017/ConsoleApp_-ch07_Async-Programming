using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumThreadsForPID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** 請輸入 PID *************");
            Console.Write("PID ：");
            string PID = Console.ReadLine();
            int procID = int.Parse(PID);
            EnumThreadsForPID(procID);
            Console.ReadLine();
            
        }

        /// <summary>
        /// 舉列執行緒
        /// </summary>
        /// <param name="procID"></param>
        private static void EnumThreadsForPID(int PID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(PID);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // 列出指定 PID 執行緒中每一個執行緒資訊
            Console.WriteLine("執行緒：{0}", proc.ProcessName);
            ProcessThreadCollection threads = proc.Threads;
            foreach(ProcessThread pt in threads)
            {
                string info = string.Format("Thread ID：{0}\t" +
                                            "Start Time：{1}\t" +
                                            "Priority：{2}",
                                            pt.Id,
                                            pt.StartTime,
                                            pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("*********************************************");
        }
    }
}
