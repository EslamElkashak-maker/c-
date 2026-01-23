using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    internal class ChooseOneQuestion : Question
    {
        public string[] Choices;
        public int CorrectIndex;

        public override bool AskQuestion()
        {
            Console.WriteLine(Text);

            for (int i = 0; i < Choices.Length; i++)
                Console.WriteLine($"{i + 1}- {Choices[i]}");

            int answer = Convert.ToInt32(Console.ReadLine()) - 1;
            return answer == CorrectIndex;

        }
    }
}
