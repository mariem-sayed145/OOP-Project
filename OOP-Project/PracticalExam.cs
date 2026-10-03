using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class PracticalExam : Exam
    {
        public PracticalExam()
        {
        }

        public PracticalExam(
            int time,
            int numberOfQuestions,
            Question[] questions)
            : base(time, numberOfQuestions, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("===== Practical Exam =====");

            foreach (Question question in Questions)
            {
                Console.WriteLine(question);

                Console.WriteLine("Answers:");

                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine(answer);
                }

                Console.WriteLine($"Right Answer: {question.RightAnswer}");
                Console.WriteLine();
            }
        }
    }
}
