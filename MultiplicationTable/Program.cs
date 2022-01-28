using System;
using System.Collections.Generic;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mTable = new int[11, 11];
            for (int i = 1; i < 11; i++)
            {
                for (int x = 1; x < 11; x++)
                {
                mTable[i, x] = i * x;
                Console.WriteLine(mTable[i, x]);
                }
            }
        }
    }
}
