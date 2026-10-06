using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Answer : ICloneable
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer() : this(0, string.Empty)
        {
        }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone()
        {
            return new Answer(AnswerId, AnswerText);
        }

        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }
}
