using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exam Exam1 = new Exam("ООП", 4, new System.DateTime(2022, 12, 23));
            Exam Exam2 = new Exam("Математический анализ", 5, new System.DateTime(2022, 12, 24));
            Exam Exam3 = new Exam("Сети", 2, new System.DateTime(2022, 12, 25));

            Test test = new Test("ОС",false);
            Test test2 = new Test("Математический анализ", true);
            Test test3 = new Test("Алгоритмы и структуры данных", true);

            Person person = new Person("Езепчук", "Кирилл", new System.DateTime(2004, 03, 02));
            Person person2 = new Person("Езепчук", "Кирилл", new System.DateTime(2002, 03, 02));

            Console.WriteLine(person.Equals(person2));
            Console.WriteLine(person != person2);
            Console.WriteLine(person.GetHashCode());
            Console.WriteLine(person2.GetHashCode());

            Student student2 = new Student(person, Education.SecondEducation, 120);
            student2.AddExams(Exam1, Exam2);
            student2.AddExams(Exam3);
            student2.AddNouns(test,test2,test3);
            Console.WriteLine(student2.ToString());
            Console.WriteLine();
            Console.WriteLine(student2.Person);
            Console.WriteLine();
            Student student1 = (Student)student2.DeepCopy();
            student2.NumberGroup=150;
            Console.WriteLine(student2.ToShortString());
            Console.WriteLine();
            Console.WriteLine(student1.ToShortString());
            Console.WriteLine();
            try 
            { 
                student1.NumberGroup = 50; 
            }
            catch (Student cf) 
            { 
                Console.WriteLine(cf.Message); 
            }
            Console.WriteLine();
            foreach (Exam exams in student1.ScoreExam(3))
            {
                Console.WriteLine(exams);
            }
            Console.WriteLine();
            foreach (var exam in student1.NounsOrExams())
            {
                Console.WriteLine(exam);
            }
            Console.WriteLine();
            foreach (String subject in student1.NounsAndExams())
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine();
            foreach (var exam in student1.PassNounsAndExams())
            { 
                Console.WriteLine(exam);
            }
            Console.WriteLine();
            foreach (Test counttest in student1.PassNouns())
            {
                Console.WriteLine(counttest);
            }
            Console.ReadKey();
        }
    }
    enum Education{Specialist,Bachelor,SecondEducation}
}
