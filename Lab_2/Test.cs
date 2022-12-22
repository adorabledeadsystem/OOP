using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class Test
    {
        public string Subject;
        public bool PassExam;
        public Test(string Subject, bool PassExam)
        {
            this.Subject = Subject;
            this.PassExam = PassExam;
        }
        public Test()
        {
            Subject = "Дисциплина";
            PassExam = false;
        }
        public override string ToString()
        {
            return Subject + " , " + PassExam;
        }
    }
}
