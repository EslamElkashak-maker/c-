using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    internal abstract class Question
    {
        public string Text;
        public int Degree;                
        public string Level; 
        public abstract bool AskQuestion();
    }
}
