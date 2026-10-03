using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class MCQQuestion : Question
    {
        public MCQQuestion()
        {
        }

        public MCQQuestion(
            string header,
            string body,
            int mark,
            Answer[] answers,
            Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }
    }
}
