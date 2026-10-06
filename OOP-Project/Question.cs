using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public abstract class Question : ICloneable, IComparable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        protected Question() : this(string.Empty, string.Empty, 0, new Answer[0], null)
        {
        }

        protected Question(string header, string body, int mark, Answer[] answerList, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        // Prints the question with its answers (no right answer, no grade)
        public virtual void Display()
        {
            Console.WriteLine(this);
            foreach (Answer a in AnswerList)
                Console.WriteLine("   " + a);
        }

        public bool IsCorrect(Answer chosen)
        {
            return chosen != null && RightAnswer != null && chosen.AnswerId == RightAnswer.AnswerId;
        }

        
        public virtual object Clone()
        {
            Question copy = (Question)MemberwiseClone();
            copy.AnswerList = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
            copy.RightAnswer = RightAnswer == null
                ? null
                : copy.AnswerList.FirstOrDefault(a => a.AnswerId == RightAnswer.AnswerId);
            return copy;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Question other = obj as Question;
            if (other == null) throw new ArgumentException("Object is not a Question");
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"{Header}: {Body} ({Mark} marks)";
        }
    }
}

