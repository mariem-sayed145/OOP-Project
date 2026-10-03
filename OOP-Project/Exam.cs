using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public abstract class Exam : ICloneable, IComparable
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Question[] Questions { get; set; }

        protected Exam()
        {
        }

        protected Exam(int time, int numberOfQuestions, Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ShowExam();

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is Exam otherExam)
                return Time.CompareTo(otherExam.Time);

            throw new ArgumentException("Object is not an Exam");
        }

        public override string ToString()
        {
            return $"Time: {Time}, Number Of Questions: {NumberOfQuestions}";
        }
    } 
}
