using ClassLibraryDZ2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAUPJC_DZ2
{
    class Program
    {

        static void Main(string[] args)
        {
            #region zad3
            int[] integers = new int[] { 1, 2, 3, 3, 3, 4, 4, 5 };

            string[] myStr = integers.GroupBy(x => x).Select(i => ("Broj " + i.Key + " ponavlja se " + i.Count() + " puta")).ToArray();

            foreach (var item in myStr) Console.WriteLine(item);
            #endregion

            #region zad4
            Example1();
            Example2();
            #endregion

            #region zad5
            //dummy list:
            University Zagreb = new University()
            {
                Name = "Zagreb"
            };
            University Split = new University()
            {
                Name = "Split"
            };

            University[] universities = new University[] { Zagreb, Split };
            Student maja = new Student("Maja", "58") { Gender = Gender.Female };
            Student pero = new Student("Pero", "59") { Gender = Gender.Male };
            Zagreb.Students = new Student[] { pero };
            Split.Students = new Student[] { maja, pero };
            
            //query
            Student[] allCroatianStudents = universities.SelectMany(b => b.Students).Distinct().ToArray();

            Student[] croatianStudentsOnMultipleUniversities= (from s in universities.SelectMany(b => b.Students)
                                                               group s by s into nGroup
                                                               where nGroup.Count() > 1
                                                               select nGroup.Key).ToArray();

            Student[] studentsOnMaleOnlyUniversities = universities.Where(u => !u.Students.Any(s => s.Gender == Gender.Female)). //male only universities
                                                       SelectMany(b => b.Students).Distinct().ToArray();                         //select distinct students

            //tests
            Console.WriteLine("allCroatianStudents.Count(): " + allCroatianStudents.Count());
            Console.WriteLine("croatianStudentsOnMultipleUniversities.Count() :" + croatianStudentsOnMultipleUniversities.Count());
            Console.WriteLine("studentsOnMaleOnlyUniversities.Count(): " + studentsOnMaleOnlyUniversities.Count());
            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// Outputs a list of todoitems to console
        /// </summary>
        /// <param name="list"></param>
        public static void PrintTodoList(List<TodoItem> list)
        {
            foreach(TodoItem item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void Example1()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :"001234567")
            };
            var ivan = new Student(" Ivan ", jmbag: "001234567");
            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
            Console.WriteLine("Example1(): " + anyIvanExists);
        }
        static void Example2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :"001234567") ,
                new Student (" Ivan ", jmbag :"001234567")
            };
            // 2 :(
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine("Example2(): " + distinctStudents);
        }
    }
}
