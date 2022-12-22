using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab_1
{
    internal class Student : Person
    {
        private Person person;
        public Person Person
        {
            get => person;
            set => person = value;
        }
        private Education education;
        public Education Education
        {
            get => education;
            set => education = value;
        }
        private List<Test> nouns=new List<Test>();
        public List<Test> Nouns
        {
            get => nouns;
            set => nouns = value;
        }
        private List<Exam> exams = new List<Exam>();

        public List<Exam> Exams
        {
            get => exams;
            set => exams = value;
        }

        private int numbergroup = 0;
        public Student(string message) : base(message) { }
        public int NumberGroup
        {
            get => numbergroup;
            set
            {
                if (value <=100 || value >599)
                {
                    throw new Student("Значение должно быть больше 100 и меньше 599");
                }
                else 
                    numbergroup=value;
            }
        }
        public DateTime Date { get; set; }
        public Student(Person person, Education education, int numbergroup)
        {
            this.person = person;
            this.education = education;
            this.numbergroup = numbergroup;
        }
        public Student() 
        {
            person = new Person("Имя", "Фамилия", new System.DateTime(1990, 01, 01));
            education = Education.Specialist;
            numbergroup = 0;
            exams= new List<Exam>();
            nouns=new List<Test>();
        }
        public override string ToString()
        {
            string examsLine = "";
            foreach(Exam exam in exams)
            {
                examsLine += " " + exam.ToString();
            }
            string nounLine = "";
            foreach (Test noun in nouns)
            {
                examsLine += " " + noun.ToString();
            }

            return person + " , " + education.ToString() + " , " + numbergroup + " , " + examsLine + " , " + nounLine + "\n";
        }
        public IEnumerable<Exam> ScoreExam(int b)
        {
            List<Exam> exams1 = new List<Exam>();
            foreach(Exam exam in exams)
            {
                if (exam.Score > b)
                {
                    exams1.Add(exam);
                }
            }
            for (int i = 0; i < exams1.Count; i++)
            {
                yield return exams1[i];
            }
        }
        public IEnumerable<Object> NounsOrExams()
        {
            List<object> NounsAndExams = new List<object>();
            int g = 0;
            foreach (Exam exam in exams)
            {
                if (g == 0)
                {
                    foreach (Test noun in nouns)
                    {
                        NounsAndExams.Add(noun);
                    }
                }
                g = 1;
                NounsAndExams.Add(exam);
            }
            for (int i = 0; i < NounsAndExams.Count; i++)
            {
                yield return NounsAndExams[i];
            }
        }
        public IEnumerable<String> NounsAndExams()
        {
            List<string> NounsAndExams=new List<string>();
            foreach(Exam exam in exams)
            {
                foreach(Test noun in nouns)
                {
                    if(exam.Subject==noun.Subject)
                    {
                        NounsAndExams.Add(exam.Subject);
                    }
                }
            }
            for (int i = 0; i < NounsAndExams.Count; i++)
            {
                yield return NounsAndExams[i];
            }
        }
        public IEnumerable<Object> PassNounsAndExams()
        {
            List<object> NounsAndExams = new List<object>();
            int g = 0;
            foreach (Exam exam in exams)
            {

                foreach (Test noun in nouns)
                {
                    if (noun.PassExam==true && g==0)
                    {
                        NounsAndExams.Add(noun);
                    }
                }
                if (exam.Score >2 )
                {
                    NounsAndExams.Add(exam);
                }
                g++;
            }
            for (int i = 0; i < NounsAndExams.Count; i++)
            {
                yield return NounsAndExams[i];
            }
        }
        public IEnumerable<Test> PassNouns()
        {
            List<Test> Nouns = new List<Test>();
            foreach (Exam exam in exams)
            {
                foreach (Test noun in nouns)
                {
                    if (exam.Score > 2 && noun.PassExam == true && exam.Subject == noun.Subject) 
                    {
                        Nouns.Add(noun);
                    }
                }
            }
            for (int i = 0; i < Nouns.Count; i++)
            {
                yield return Nouns[i];
            }
        }
        public double AverageValueExam
        {
            get
            {
                double AverageValue = 0;
                int Sum = 0;
                int Count = 0;
                foreach (Exam exam in exams)
                {
                    Sum += exam.Score;
                    Count++;
                }
                if (Count == 0)
                    Count = 1;
                AverageValue = Sum / Count;
                return AverageValue;
            }
        }
        public bool this[Education education]
        {
            get
            {
                if (this.education == education)
                    return true;
                else return false;
            }
        }
        public void AddExams( params Exam[] exams)
        {
            this.exams.AddRange(exams);  
        }
        public void AddNouns(params Test[] nouns)
        {
            this.nouns.AddRange(nouns);
        }
        public virtual new string  ToShortString()
        {
            return "Данные студента: " + person + ", " + "Образование: " + education + ", " + "Номер группы: " + numbergroup + ", " + "Средний балл: " + AverageValueExam+ "Количество зачетов: " + exams.Count+ "Количество экзаменов: " + nouns.Count;
        }
    public virtual new object DeepCopy()
        {
            Student student = new Student(person,education,numbergroup);
            List<Test> arrnouns = new List<Test>();
            List<Exam> arrexams = new List<Exam>();
            student.exams = arrexams;
            student.nouns = arrnouns;
            arrexams.AddRange(exams);
            arrnouns.AddRange(nouns);
            return student;
        }
    }
   
}
