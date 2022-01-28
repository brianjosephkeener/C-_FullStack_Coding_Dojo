using System;
using System.Collections.Generic;
namespace Basic13
{
    class Program
    {
    public static void PrintNumbers()
{
    // Print all of the integers from 1 to 255.
    for (int i = 1; i <= 255; i++)
    {
    Console.WriteLine(i);
    }
}
    public static void PrintOdds()
    {
    // Print all of the odd integers from 1 to 255.
    for (int i = 1; i <= 255; i = i + 2)
    {
        Console.WriteLine(i);
    }
    }
    public static void PrintSum()
{
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go. 
    // For example, your output should be something like this:
    
    // New number: 0 Sum: 0
    // New number: 1 Sum: 1
    // New Number: 2 Sum: 3
    int sum = 0;
    for (int i = 0; i <= 255; i++)
    {
        sum = sum + i;
        Console.WriteLine($"New number: {i} Sum: {sum}");
    }
}
public static void LoopArray(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine(numbers[i]);
    }
}
public static int FindMax(int[] numbers)
{
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.
    int max = Int32.MinValue;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (max < numbers[i])
        {
            max = numbers[i];
        }
    }
    return max;
}
public static void GetAverage(int[] numbers)
{
    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.
    int sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        sum = sum + numbers[i];
    }
    double average = (double)sum / numbers.Length;
    Console.WriteLine($"Average is {average}");
}
public static int[] OddArray()
{
    // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
    // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
    int[] array = new int[255];
    int indexpone = 0;
    for (int i = 1; i < array.Length; i = i + 2)
    {
        array[indexpone] = i;
        Console.WriteLine(array[indexpone]);
        indexpone++;
    }
    return array;
}
public static int GreaterThanY(int[] numbers, int y)
{
    // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
    // That are greater than the "y" value. 
    // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
    // (since there are two values in the array that are greater than 3).
    short greater = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > y)
        {
            greater++;
        }
    }
    return greater;
}
public static void SquareArrayValues(int[] numbers)
{
    // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = numbers[i] * numbers[i];
        Console.WriteLine(numbers[i]);
    }
}
public static void EliminateNegatives(int[] numbers)
{
    // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
    for (int i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] < 0)
        {
            numbers[i] = 0;
        }
        Console.WriteLine(numbers[i]);
    }
}
public static void MinMaxAverage(int[] numbers)
{
    // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
    // the minimum value in the array, and the average of the values in the array.
    int max = Int32.MinValue;
    int min = Int32.MaxValue;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
        }
        if (numbers[i] < min)
        {
            min = numbers[i];
        }
        
    }
    GetAverage(numbers);
    Console.WriteLine($"Max is: {max}");
    Console.WriteLine($"Min is: {min}");
}
public static void ShiftValues(int[] numbers)
{
    // Given an integer array, say [1, 5, 10, 7, -2], 
    // Write a function that shifts each number by one to the front and adds '0' to the end. 
    // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
    // it should become [5, 10, 7, -2, 0].
    int nextIndex = 1;
    for (int i = 0; i < numbers.Length; i++)
    {
        if (i == (numbers.Length - 1))
        {
            numbers[i] = 0;
            Console.WriteLine(numbers[i]);
            break;
        }
        numbers[i] = numbers[nextIndex];
        nextIndex++;
        Console.WriteLine(numbers[i]);
    }
}
public static object[] NumToString(int[] numbers)
        {
            object[] newArr = new object[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] < 0)
                    newArr[i] = "Dojo";
                else
                    newArr[i] = numbers[i];
            }
            return newArr;
        }
        static void Main(string[] args)
        {
            //PrintNumbers();
            //PrintOdds();
            //PrintSum();
            int[] array, negarray, mixarray;
            array = new int[] {1, 5, 100, 15};
            negarray = new int[] {-1, -5, -100, -15};
            mixarray = new int[] {-1, 5, -100, 15};
            //LoopArray(array);
            //Console.WriteLine(FindMax(array));
            //Console.WriteLine(FindMax(negarray));
            //Console.WriteLine(FindMax(mixarray));
            //GetAverage(array);
            //GetAverage(negarray);
            //GetAverage(mixarray);
            //OddArray();
            //Console.WriteLine(GreaterThanY(array, 2));
            //SquareArrayValues(array);
            //EliminateNegatives(mixarray);
            //MinMaxAverage(array);
            //ShiftValues(array);
            NumToString(mixarray);
        }
    }
}
