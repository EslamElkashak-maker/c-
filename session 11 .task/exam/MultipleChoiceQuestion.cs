using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    internal class MultipleChoiceQuestion : Question
    {
        public string[] Choices;
        public int[] CorrectIndexes;

        public override bool AskQuestion()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Choices.Length; i++)
                Console.WriteLine($"{i + 1}- {Choices[i]}");
            Console.WriteLine("Enter all correct choice numbers separated by space:");
            string[] parts = Console.ReadLine().Split(' ');
            int[] userAnswers = Array.ConvertAll(parts, x => Convert.ToInt32(x) - 1);
           // Array.Sort(userAnswers);

            //Array.Sort(CorrectIndexes);
            return userAnswers.Length == CorrectIndexes.Length;

        }
    }
       
}
