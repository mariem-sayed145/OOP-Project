using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answerList, int rightAnswerId)
            : base(header, body, mark, answerList,
                   answerList == null ? null : answerList.FirstOrDefault(a => a.AnswerId == rightAnswerId))
        {
            if (answerList == null || answerList.Length < 2)
                throw new ArgumentException("MCQ needs at least 2 answers.");
            if (RightAnswer == null)
                throw new ArgumentException("Right answer id must match one of the answers.");
        }
    }
}
