using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Declare Variables
        List<int> numbers = new List<int>();
        int input = 0;
        int sum = 0;
        float average = 0;

        // Get list of integers from user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            numbers.Add(input);
        } while (input != 0);
        numbers.RemoveAt(numbers.Count-1);  // Remove the '0' element at the end.
        
        // Compute the sum of the numbers in the list
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Compute the average of the numbers in the list
        float count = numbers.Count;
        average = sum / count;
        
        // Organize the list
        numbers.Sort(); // Put the list in ascending order
        numbers.Reverse();  // Put the list in descending order. Largest # 1st.

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {numbers[0]}");

        // Sort the number from smallest to largest.
        numbers.Sort(); // Ascending order
        foreach (int number in numbers)
        {
            // Search for the first number that is greater than zero
            if (number > 0)
            {
                Console.WriteLine($"The smallest positive number is: {number}");
                break; // Exit the loop
            }
        }

        // Display the list
        Console.WriteLine("The sorted list is: ");
        numbers.ForEach(delegate(int num)
        {
            Console.WriteLine(num);
        });
    }
}