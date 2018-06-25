using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel類別
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 下 Parallel 類別，簡化同步狀態下對 Task 操作，提供平行迴圈和區域的支援
            //主要三個方法 For、ForEach、Invoke
            //陣列並未按照索引順序來遍歷，這是因為遍歷是平行的，不是順序，如果需要順序性 Parallel 就不適合
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("索引 {0} : 陣列 {1} ", i, nums[i]);
            });
            Console.ReadLine();

            //Parallel.ForEac 取出時就不在有順序性
            List<int> nums1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Parallel.ForEach(nums1, (i) => {
                Console.WriteLine("集合元素 {0}", i);
            });
            Console.ReadLine();

            Parallel.Invoke(() =>
            {
                Console.WriteLine("工作 1....");
            }, () =>
            {
                Console.WriteLine("工作 2...");
            }, () =>
            {
                Console.WriteLine("工作 3...");
            });
            Console.ReadLine();
        }
    }
}
