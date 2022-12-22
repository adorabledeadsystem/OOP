using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_1
{
    internal class TestCollections
    {
        List<Person> persons;
        List<string> str;
        Dictionary<string, Student> strstudents;
        Dictionary<Person, Student> students;
        public void GenerateStudent(int value)
        {
            for(int i=1; i < value; i++)
            {
                Person person = new Person();
                persons.Add(person);
                str.Add(person.ToString());
                Student student = new Student();
                strstudents.Add(student.ToString(), student);
                students.Add(person, student);

            }
        }
        public TestCollections(int value)
        {
            persons = new List<Person>(value);
            str = new List<string>(value);
            strstudents = new Dictionary<string, Student>(value);
            students = new Dictionary<Person, Student>(value);
        }
        public void SearchTime()
        {
            int t1 = Environment.TickCount;
            persons.Contains(persons[0]);
            int t2 = Environment.TickCount;
            Console.WriteLine($"Время поиска первого элемента в List<Person>: {t2 - t1}; " + persons[0].ToString());
            int t3 = Environment.TickCount;
            persons.Contains(persons[persons.Count/2-1]);
            int t4 = Environment.TickCount;
            Console.WriteLine($"Время поиска центрального элемента в List<Person>: {t4 - t3}; " + persons[persons.Count / 2 - 1].ToString());
            int t5 = Environment.TickCount;
            persons.Contains(persons[persons.Count - 1]);
            int t6 = Environment.TickCount;
            Console.WriteLine($"Время поиска последнего элемента в List<Person>: {t6 - t5}; " + persons[persons.Count- 1].ToString());
            int t7 = Environment.TickCount;
            persons.Contains(new Person());
            int t8 = Environment.TickCount;
            Console.WriteLine($"Время поиска элемента, которого нет в List<Person>: {t8 - t7}");
            
            int t9 = Environment.TickCount;
            str.Contains(str[0]);
            int t10 = Environment.TickCount;
            Console.WriteLine($"Время поиска первого элемента в List<string>: {t10 - t9}; " + str[0].ToString());
            int t11 = Environment.TickCount;
            str.Contains(str[str.Count / 2 - 1]);
            int t12 = Environment.TickCount;
            Console.WriteLine($"Время поиска центрального элемента в List<string>: {t12 - t11}; " + str[str.Count / 2 - 1].ToString());
            int t13 = Environment.TickCount;
            str.Contains(str[str.Count - 1]);
            int t14 = Environment.TickCount;
            Console.WriteLine($"Время поиска последнего элемента в List<string>: {t14 - t13}; " + str[str.Count - 1].ToString());
            int t15 = Environment.TickCount;
            str.Contains("gg");
            int t16 = Environment.TickCount;
            Console.WriteLine($"Время поиска элемента, которого нет в List<string>: {t16 - t15}");

        }
    }
}
