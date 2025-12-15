using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = [];
        char choice;

        do
        {
            Console.WriteLine("\nP - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("Q - Quit");

            Console.Write("Enter your choice: ");
            choice =Convert.ToChar( Console.ReadLine().ToUpper()[0]);

            if (choice == 'P')
            {
                if (numbers.Count == 0)
                    Console.WriteLine("List is empty");
                else
                {
                    for (int i = 0; i < numbers.Count; i++)
                        Console.Write(numbers[i] + " ");
                    Console.WriteLine();
                }
            }

            else if (choice == 'A')
            {
                Console.Write("Enter a number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                numbers.Add(num);
                Console.WriteLine("Number added");
            }

            else if (choice == 'M')
            {
                if (numbers.Count == 0)
                    Console.WriteLine("List is empty");
                else
                {
                    int sum = 0;
                    for (int i = 0; i < numbers.Count; i++)
                        sum += numbers[i];

                    double mean = (double)sum / numbers.Count;
                    Console.WriteLine("Mean = " + mean);
                }
            }

            else if (choice == 'S')
            {
                if (numbers.Count == 0)
                    Console.WriteLine("List is empty");
                else
                {
                    int smallest = numbers[0];
                    for (int i = 1; i < numbers.Count; i++)
                        if (numbers[i] < smallest)
                            smallest = numbers[i];

                    Console.WriteLine("Smallest = " + smallest);
                }
            }

            else if (choice == 'L')
            {
                if (numbers.Count == 0)
                    Console.WriteLine("List is empty");
                else
                {
                    int largest = numbers[0];
                    for (int i = 1; i < numbers.Count; i++)
                        if (numbers[i] > largest)
                            largest = numbers[i];

                    Console.WriteLine("Largest = " + largest);
                }
            }

            else if (choice == 'F')
            {
                Console.Write("Enter number to find: ");
                int search =Convert.ToInt32(Console.ReadLine());

                bool found = false;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == search)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    Console.WriteLine("Number found");
                else
                    Console.WriteLine("Number not found");
            }

            else if (choice == 'C')
            {
                numbers.Clear();
                Console.WriteLine("List cleared");
            }

        } while (choice != 'Q');

        Console.WriteLine("Goodbye!");
    }
}