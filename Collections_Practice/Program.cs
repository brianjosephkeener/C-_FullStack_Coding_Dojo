using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            short[] numArray = new short[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Console.WriteLine(numArray[9]);
            string[] strArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            Console.WriteLine(strArray[1]);
            bool[] tfArray = new bool[] {true, false, true, false, true, false, true, false, true, false};
            Console.WriteLine(tfArray[1]);

            List<string> icecream = new List<string>();
            icecream.Add("Vanilla");
            icecream.Add("Chocolate");
            icecream.Add("Sherbert");
            icecream.Add("Mint");
            icecream.Add("Rainbow");
            for (int i = 0; i < icecream.Count; i++)
            {
                Console.WriteLine(icecream[i]);
            }
             Console.WriteLine(icecream[1]);
            icecream.Remove("Chocolate");
            for (int i = 0; i < icecream.Count; i++)
            {
                Console.WriteLine(icecream[i]);
            }
            Random rand = new Random();
            Dictionary<string,string> favflavor = new Dictionary<string,string>();
            favflavor.Add(strArray[0], icecream[rand.Next(0, 4)]);
            favflavor.Add(strArray[1], icecream[rand.Next(0, 4)]);
            favflavor.Add(strArray[2], icecream[rand.Next(0, 4)]);
            favflavor.Add(strArray[3], icecream[rand.Next(0, 4)]);
            foreach (var entry in favflavor)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
