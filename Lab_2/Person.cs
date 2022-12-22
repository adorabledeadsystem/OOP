using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_1
{
    internal class Person : Exception, IDateAndCopy
    {
        public Person(string message) : base(message) { }
        protected string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        protected string surname;
        public string SurName
        {
            get => surname;
            set => surname = value;
        }
        public DateTime Date { get; set; }
        protected System.DateTime birthday;
        public System.DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }
        public Person(string name, string surname, System.DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }
        public Person()
        {
            name = "Имя";
            surname = "Фамилия";
            birthday = new System.DateTime(1990, 01, 01);
        }

        public int birthday_year
        {
            get => birthday_year;
            set => birthday = new System.DateTime(birthday_year, birthday.Month, birthday.Day);
        }
        public override string ToString()
        {
            return name + ", " + surname + ", " + birthday;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person obj1 = obj as Person;
            if (obj1.Name == name && obj1.SurName == surname && obj1.Birthday == birthday)
            {
                return true;
            }
            else
                return false;
        }
        public object DeepCopy() => new Person(name, surname, birthday);
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);
        public override int GetHashCode()
        {
            return Tuple.Create(name, surname, birthday).GetHashCode();
        }
        public string ToShortString()
        {
            return "Имя: " + name + ", " + "Фамилия: " + surname;
        }

      
    }
}
