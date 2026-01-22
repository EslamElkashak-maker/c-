using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace exam
{
    internal class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer;

        public override bool AskQuestion()
        {
            Console.WriteLine(Text);
            Console.WriteLine("1- True");
            Console.WriteLine("2- False");  
            int answer =Convert.ToInt32( Console.ReadLine());
            if (answer == 1 && CorrectAnswer)
                return true;
            else if (answer == 2 && !CorrectAnswer)
                return true;
            else
                return false;


        }
    }
}
