using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassLibraryDZ2.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        //TODO: add more tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }
        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }
        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }
        [TestMethod]
        public void UpdateAddsNewItemAndUpdatesExisting()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Update(todoItem);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
            todoItem.Text = "Not Groceries";
            repository.Update(todoItem);
            Assert.IsTrue(repository.Get(todoItem.Id).Text == todoItem.Text);
        }
        [TestMethod]
        public void RemoveTest()
        {
            ITodoRepository repo = new TodoRepository();
            var item = new TodoItem("Groceries");
            repo.Add(item);
            repo.Remove(item.Id);
            Assert.IsTrue(repo.Get(item.Id) == null);
        }
        [TestMethod]
        public void GetTest()
        {
            ITodoRepository repo = new TodoRepository();
            var item = new TodoItem("Groceries");
            repo.Add(item);
            Assert.IsTrue(repo.Get(item.Id).Id == item.Id);
        }
    }
}
