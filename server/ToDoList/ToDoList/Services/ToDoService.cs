using ToDoList.Models;

namespace ToDoList.Services
{
    public class ToDoService
    {
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>();
        private static int _nextId = 1;

        public IEnumerable<ToDoItem> GetAll() => _toDoItems;

        public ToDoItem Get(int id) => _toDoItems.FirstOrDefault(item => item.Id == id);

        public ToDoItem Add(ToDoItem item)
        {
            item.Id = _nextId++;
            _toDoItems.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            var item = Get(id);
            if (item != null) _toDoItems.Remove(item);
        }

        public void Update(ToDoItem item)
        {
            var index = _toDoItems.FindIndex(x => x.Id == item.Id);
            if (index != -1) _toDoItems[index] = item;
        }
    }
}
