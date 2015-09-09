namespace SimpleApp.Model
{
    /// <summary>
    /// Defines the structure of a ToDoItem. This class acts like a contract between the components(layers) for data structure
    /// </summary>
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool Completed { get; set; }
    }
}
