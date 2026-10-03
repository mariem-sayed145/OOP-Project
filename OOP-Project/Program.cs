using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    class Program
    {
        static void Main()
        {
            // Create Subject
            Subject subject = new Subject(1, "C#");

            // Create Answers
            Answer answer1 = new Answer(1, "Programming Language");
            Answer answer2 = new Answer(2, "Database");
            Answer answer3 = new Answer(3, "Operating System");

            Answer[] answers =
            {
            answer1,
            answer2,
            answer3
        };

            // Create Question
            Question question1 = new MCQQuestion(
                "Question 1",
                "What is C#?",
                5,
                answers,
                answer1
            );

            Question[] questions =
            {
            question1
        };

            // Create Final Exam
            FinalExam finalExam = new FinalExam(
                60,
                questions.Length,
                questions
            );

            // Assign Exam to Subject
            subject.CreateExam(finalExam);

            // Show Exam
            subject.Exam.ShowExam();

            Console.ReadLine();
        }
    }
}
