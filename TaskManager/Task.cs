namespace TaskManager
{

    public class Task
    {
        // Properties, using { get; set; } to make them auto-implemented properties
        public Guid id { get; set; }
        public string title { get; set; }
        public DateTime dueDate { get; set; }
        public bool isCompleted { get; set; }

        public Task() { }

        public Task(string givenTitle, DateTime givenDueDate)
        {
            id = Guid.NewGuid();
            title = givenTitle;
            dueDate = givenDueDate;
            isCompleted = false;
        }

    }
}