
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public interface ITodoservices
    {
        List<TodoModel> GetToDoList();
        bool AddNewToDo(string title, ref string sErr);
        bool UpdateToDo(TodoModel model, ref string sErr);
        bool DeleteToDo(string ID);

    }
}
