using System;

namespace ClassLibraryDZ2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() : base("Item already in repository!")
        {

        }
    }
}
