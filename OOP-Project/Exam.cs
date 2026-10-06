using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public enum ExamType { Final = 1, Practical = 2 }

    public abstract class Exam : ICloneable, IComparable
    {
        public int Time { get; set; }                       
        public Question[] Questions { get; private set; }
        public Subject Subject { get; set; }                // every exam belongs to a subject
        public Answer[] StudentAnswers { get; protected set; }
        public bool IsFinished { get; protected set; }

        public int NumberOfQuestions { get { return Questions.Length; } }
        public int TotalMarks { get { return Questions.Sum(q => q.Mark); } }

        protected Exam(int time, Question[] questions)
        {
            if (questions == null || questions.Length == 0)
                throw new ArgumentException("Exam needs at least one question.");

            foreach (Question q in questions)
                if (!IsQuestionAllowed(q))
                    throw new ArgumentException($"{GetType().Name} does not accept {q.GetType().Name}.");

            Time = time;
            Questions = questions;
            StudentAnswers = new Answer[questions.Length];
        }

        // Each exam type decides which question types it accepts
        protected abstract bool IsQuestionAllowed(Question question);

        // Different implementation for each exam type
        public abstract void ShowExam();

        // Student answers all the questions
        public void TakeExam()
        {
            Console.WriteLine($"\n--- {GetType().Name} | Time: {Time} min | Questions: {NumberOfQuestions} ---\n");

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].Display();
                StudentAnswers[i] = ReadAnswer(Questions[i]);
                Console.WriteLine();
            }
            IsFinished = true;
        }

        private static Answer ReadAnswer(Question q)
        {
            while (true)
            {
                Console.Write("Your answer (id): ");
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    Answer chosen = q.AnswerList.FirstOrDefault(a => a.AnswerId == id);
                    if (chosen != null) return chosen;
                }
                Console.WriteLine("Invalid choice, try again.");
            }
        }

        protected int CalculateGrade()
        {
            int grade = 0;
            for (int i = 0; i < Questions.Length; i++)
                if (Questions[i].IsCorrect(StudentAnswers[i]))
                    grade += Questions[i].Mark;
            return grade;
        }

        protected bool EnsureFinished()
        {
            if (!IsFinished) Console.WriteLine("The exam has not been taken yet.");
            return IsFinished;
        }

        public virtual object Clone()
        {
            Exam copy = (Exam)MemberwiseClone();
            copy.Questions = Questions.Select(q => (Question)q.Clone()).ToArray();
            copy.StudentAnswers = new Answer[Questions.Length];
            copy.IsFinished = false;
            return copy;               // Subject is intentionally shared
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Exam other = obj as Exam;
            if (other == null) throw new ArgumentException("Object is not an Exam");
            return Time.CompareTo(other.Time);
        }

        public override string ToString()
        {
            string subj = Subject == null ? "-" : Subject.SubjectName;
            return $"{GetType().Name} | Subject: {subj} | Time: {Time} min | Questions: {NumberOfQuestions} | Total: {TotalMarks}";
        }
    }
}
