namespace ToDoListApp.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDateTime { get;set; }
    }
}
