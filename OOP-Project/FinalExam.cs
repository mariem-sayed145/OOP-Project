using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, Question[] questions) : base(time, questions)
        {
        }

        // Final exam: True/False and MCQ
        protected override bool IsQuestionAllowed(Question q)
        {
            return q is TrueFalseQuestion || q is MCQQuestion;
        }

        // Shows the questions, the answers and the grade
        public override void ShowExam()
        {
            if (!EnsureFinished()) return;

            Console.WriteLine("\n===== Final Exam Result =====");
            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].Display();
                Console.WriteLine($"   Your answer: {StudentAnswers[i]}");
                Console.WriteLine();
            }
            Console.WriteLine($"Grade: {CalculateGrade()} / {TotalMarks}");
        }
    }
}
