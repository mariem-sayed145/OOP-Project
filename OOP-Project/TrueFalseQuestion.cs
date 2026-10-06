using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class TrueFalseQuestion : Question
    {
        
        public TrueFalseQuestion(string header, string body, int mark, bool correctAnswerIsTrue)
            : base(header, body, mark,
                   new Answer[] { new Answer(1, "True"), new Answer(2, "False") },
                   null)
        {
            RightAnswer = AnswerList[correctAnswerIsTrue ? 0 : 1];
        }
    } 
}
