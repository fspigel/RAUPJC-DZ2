namespace RAUPJC_DZ2
{
    class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }        public Gender Gender { get; set; }
        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Jmbag == student2.Jmbag;
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return student1.Jmbag != student2.Jmbag;
        }

        public override bool Equals(object obj)
        {
            if (GetType() == obj.GetType())
            {
                Student tempStudent = (Student)obj;
                if (Jmbag == tempStudent.Jmbag)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach(char c in Jmbag)
            {
                hash += c.GetHashCode();
            }
            return hash;
        }
    }

    public enum Gender
    {
        Male, Female
    }

}
