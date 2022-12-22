using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Exam: IDateAndCopy
    {
        public string Subject;
        public int Score;
        public DateTime Date { get; set; }
        public System.DateTime DataExam;
        public Exam(string Subject, int Score, System.DateTime DataExam)
        {
            this.Subject = Subject;
            this.Score = Score;
            this.DataExam = DataExam;
        }
        public Exam()
        {
            Subject = "Дисциплина";
            Score = 2;
            DataExam = new System.DateTime(1990, 01, 01);
        }
        public override string ToString()
        {
            return Subject + " , " + Score + " , " + DataExam;
        }

        public object DeepCopy()
        {
            throw new NotImplementedException();
        }
    }
}
