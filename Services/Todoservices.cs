using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class Todoservices:ITodoservices
    {
        private List<TodoModel> _todos = new List<TodoModel>();

        public List<TodoModel> GetToDoList()
        {
            return _todos;
        }

        public bool AddNewToDo(string title, ref string sError)
        {
            bool proceedToAdd = true;
            if(!string.IsNullOrEmpty(title))
            {
                if(_todos.Any())
                {
                    foreach(var line in _todos)
                    {
                        if(line.Title.ToLower() == title.ToLower())
                        {
                            sError = "To-DO with Similar Tile Already exists";
                            proceedToAdd = false;
                            break;
                        }
                    }
                    
                }

                if(proceedToAdd)
                {
                    TodoModel toadd = new TodoModel
                    {
                        Id = Guid.NewGuid(),
                        Title = title,
                        IsCompleted = false,
                        CreatedDateTime = DateTime.Now
                    };
                    _todos.Add(toadd);
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                sError = "Title Cannot Be Empty";
                return false;
            }
        }

        public bool UpdateToDo(TodoModel modelToUpdate,ref string sError)
        {
            //bool proceedOK = true;
            if(_todos.Any(x=>x.Title.ToLower() == modelToUpdate.Title.ToLower() && x.Id.ToString() != modelToUpdate.Id.ToString()))
            {
                sError = "Duplicate Titile";
                return false;
            }
            if (_todos.Where(x=> x.Id.ToString() == modelToUpdate.Id.ToString()).Count() == 0)
            {
                sError = "ID Not Found";
                return false;
            }


            try
            {
                foreach (var todo in _todos)
                {
                    if (todo.Id == modelToUpdate.Id)
                    {
                        todo.IsCompleted = modelToUpdate.IsCompleted;
                        todo.Title = modelToUpdate.Title;
                        break;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                sError += ex.ToString();
                return false;
            }
        }

        public bool DeleteToDo(string id)
        {
            int index = _todos.FindIndex(x => x.Id.ToString() == id);
            _todos.RemoveAt(index);

            return true;
        }
    }
}
