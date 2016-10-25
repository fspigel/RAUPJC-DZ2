using dz1_zad3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDZ2
{
    public class TodoRepository : ITodoRepository
    {
        private GenericList<TodoItem> _intCollection { get; set; }

        public TodoItem Get(Guid ID)
        {
            return _intCollection.FirstOrDefault(item => item.Id == ID);
        }

        public void Add(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (Get(item.Id) == item)
            {
                throw new DuplicateTodoItemException();
            }
            _intCollection.Add(item);
        }

        public bool Remove(Guid ID)
        {
            return _intCollection.Remove(Get(ID));
        }

        public void Update(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null)
            {
                Add(todoItem);
                return;
            }
            TodoItem tempItem = Get(todoItem.Id);
            tempItem = todoItem;
            //TODO: TEST THIS!! 
        }

        public bool MarkAsCompleted(Guid ID)
        {
            //fail condition unclear
            TodoItem tempItem = Get(ID);
            //TODO: test default(TodoItem)
            if (tempItem != default(TodoItem))
            {
                tempItem.MarkAsCompleted();
                return true;
            }
            return false;
        }

        public List<TodoItem> GetAll()
        {
            return _intCollection.OrderByDescending(item => item.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _intCollection.Where(item => item.DateCompleted == default(DateTime)).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _intCollection.Where(item => item.DateCompleted != default(DateTime)).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _intCollection.Where(item => filterFunction(item)).ToList();
        }

        public TodoRepository()
        {
            _intCollection = new GenericList<TodoItem>();
        }

        public void Printf()
        {
            foreach(TodoItem item in _intCollection)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", item.Id, item.Text, item.DateCreated, item.DateCompleted);
            }
        }
    }
}
