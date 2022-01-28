using System;
using System.Collections.Generic;

namespace BoxingUnBoxing
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmptyList = new List<object>();
            EmptyList.Add(7);
            EmptyList.Add(28);
            EmptyList.Add(-1);
            EmptyList.Add(true);
            EmptyList.Add("chair");

            int sum = 0;
            foreach(var item in EmptyList)
            {
                Console.WriteLine(item);
                if(item is int)
                {
                    Console.WriteLine("Int");
                    sum += (int)item;
                    Console.WriteLine($"Current sum: {sum}");
                }
            }
        }
    }
}
