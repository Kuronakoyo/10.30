using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0 ~ 10 までの配列を作成して

            var datas = Enumerable.Range(0, 10).ToList();
            datas.ForEach(x => Console.Write(x.ToString() + ","));
            Console.WriteLine("");

            //var findAllList = list.FindAll(x => x % 2 == 0);
 
            //偶数だけを取り出して表示
            datas.Where(x => (x % 2) == 0)
                .ToList()
                .ForEach(x => Console.Write(x.ToString() + "+"));
            Console.WriteLine("");

           /*var list = new List<int> { 1,2,3,4,5,6,7,8,9,10};
            var findAllList = list.FindAll(x => x % 2 == 0);
            Console.WriteLine("=== 偶数だけ取り出す ===");
            foreach (var x in findAllList)
            {
                Console.WriteLine(x);
            }
           */
        }
    }
}
