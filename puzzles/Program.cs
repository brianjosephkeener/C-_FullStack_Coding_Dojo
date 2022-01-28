using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static int[] RandomArray()
        {
            int[] numbers = new int[11];
            Random rand = new Random();
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            for (int i = 0; i < 11; i++)
            {
                numbers[i] = rand.Next(5, 26);
                Console.WriteLine(numbers[i]);
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }
            Console.WriteLine($"This is Max: {max} and this is Min: {min}");
            return numbers;
        }
        public static string TossCoin()
        {
            Random rand = new Random();
            Console.WriteLine("Tossing a Coin!");
            if (rand.Next(0, 2) == 1)
            {
                Console.WriteLine("Heads");
                return "Heads";
            }
            else
            {
                Console.WriteLine("Tails");
                return "Tails";
            }
        }
        public static double TossMultipleCoins(int num)
        {
            int hTotal = 0;
            int tTotal = 0;
            Random rand = new Random();
            for (int i = 0; i <= num; i++)
            {
                if(rand.Next(0, 2) == 1)
                {
                    hTotal = hTotal + 1;
                }
                else
                {
                    tTotal = tTotal + 1;
                }
            }
            return (double)hTotal/num;
        }
        public static List<string> Names()
        {
            List<string> names = new List<string>()
            {
                "Todd", "Tiffany", "Charile", "Geneva", "Sydney"
            };
            Random rand = new Random();
            for (int i = 0; i < names.Count/2; i++)
            {
                int randomIndex = rand.Next(names.Count);
                string temp = names[randomIndex];
                names[randomIndex] = names[i];
                names[i] = temp;
            }
            for (var i = 0; i < names.Count; i++)
            {
                if(names[i].Length <= 5)
                {
                    names.RemoveAt(i);
                }
                Console.WriteLine(names[i]);
            }
            return names;
        }
        static void Main(string[] args)
        {
            //RandomArray();
            //TossCoin();
            //Console.WriteLine(TossMultipleCoins(10));
            Names();
        }
    }
}
