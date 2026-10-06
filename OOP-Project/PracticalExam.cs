using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, Question[] questions) : base(time, questions)
        {
        }

        // Practical exam: MCQ only
        protected override bool IsQuestionAllowed(Question q)
        {
            return q is MCQQuestion;
        }

        // Shows the right answers after finishing the exam
        public override void ShowExam()
        {
            if (!EnsureFinished()) return;

            Console.WriteLine("\n===== Practical Exam - Right Answers =====");
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                Console.WriteLine($"   Your answer : {StudentAnswers[i]}");
                Console.WriteLine($"   Right answer: {Questions[i].RightAnswer}");
                Console.WriteLine();
            }
        }
    }
}
