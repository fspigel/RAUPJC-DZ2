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
        public static void PrintTodoList(List<TodoItem> list)
        {
            foreach(TodoItem item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void Main(string[] args)
        {
            //TodoRepository repo = new TodoRepository();
            //repo.Add(new TodoItem("item1"));
            //repo.Add(new TodoItem("item2"));
            //TodoItem item3 = new TodoItem("item3");
            //repo.Add(item3);
            //repo.MarkAsCompleted(item3.Id);
            //Console.WriteLine("GetAll:");
            //PrintTodoList(repo.GetAll());
            //Console.WriteLine("\nGetActive:");
            //PrintTodoList(repo.GetActive());
            //Console.WriteLine("\nGetCompleted:");
            //PrintTodoList(repo.GetCompleted());

            //zad3

            //zad4
            Example1();
            Example2();

            Console.ReadLine();
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
            Console.WriteLine(anyIvanExists);
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
            Console.WriteLine(distinctStudents);
        }
    }
}
