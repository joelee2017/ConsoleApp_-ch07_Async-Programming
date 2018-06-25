using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Write51To100
{
    class Program
    {
        static void Main(string[] args)
        {
            //程式進行 Main 會建立主執行緒，因為只有一條執行緒，程式會依序執行
            //WritelTo50();
            //Write51To100();

            //建立新執行緒執行 WritelTo50 ，而 Write51To100 留給主執行緒執行
            Thread t = new Thread(WritelTo50);

            t.Start();

            Write51To100();

            Console.ReadLine();
        }

        static void WritelTo50()
        {
            for(int i= 1; i <= 50; i++)
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
