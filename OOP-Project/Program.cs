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
            Subject subject = new Subject(1, "C# & OOP");
            Console.WriteLine(subject);

            ExamType type = ReadExamType();
            Question[] questions = BuildQuestions(type);

            subject.CreateExam(type, 30, questions);
            Console.WriteLine(subject.Exam);

            // Demo: ICloneable + IComparable
            Exam copy = (Exam)subject.Exam.Clone();
            Console.WriteLine($"Clone equal time? {subject.Exam.CompareTo(copy) == 0}");

            subject.Exam.TakeExam();
            subject.Exam.ShowExam();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        static ExamType ReadExamType()
        {
            while (true)
            {
                Console.Write("Choose exam type (1 = Final, 2 = Practical): ");
                string s = Console.ReadLine();
                if (s == "1") return ExamType.Final;
                if (s == "2") return ExamType.Practical;
                Console.WriteLine("Invalid choice.");
            }
        }

        static Question[] BuildQuestions(ExamType type)
        {
            Question mcq1 = new MCQQuestion("Q1", "What is C#?", 5,
                new Answer[] { new Answer(1, "Programming language"), new Answer(2, "Database"), new Answer(3, "Operating system") }, 1);

            Question mcq2 = new MCQQuestion("Q2", "Which keyword is used for inheritance?", 5,
                new Answer[] { new Answer(1, "implements"), new Answer(2, ":"), new Answer(3, "extends"), new Answer(4, "inherits") }, 2);

            if (type == ExamType.Practical)
                return new Question[] { mcq1, mcq2 };          // MCQ only

            Question tf = new TrueFalseQuestion("Q3", "An abstract class can be instantiated.", 2, false);
            return new Question[] { tf, mcq1, mcq2 };          // Final: T/F + MCQ
        }
    }
}
