using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAUPJC_DZ2
{
    class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        //public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }        public enum Gender
        {
            Male, Female
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Jmbag == student2.Jmbag;
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return student1.Jmbag != student2.Jmbag;
        }
    }
}
