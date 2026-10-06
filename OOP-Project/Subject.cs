using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; private set; }

        public Subject() : this(0, string.Empty)
        {
        }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        // Creates the exam of the right type and links it to this subject
        public Exam CreateExam(ExamType type, int time, Question[] questions)
        {
            switch (type)
            {
                case ExamType.Final: Exam = new FinalExam(time, questions); break;
                case ExamType.Practical: Exam = new PracticalExam(time, questions); break;
                default: throw new ArgumentException("Unknown exam type.");
            }
            Exam.Subject = this;
            return Exam;
        }

        public override string ToString()
        {
            return $"Subject {SubjectId}: {SubjectName}";
        }
    }
}
