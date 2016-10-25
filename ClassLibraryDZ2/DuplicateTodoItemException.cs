using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDZ2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() : base("Item already in repository!")
        {

        }
    }
}
