namespace TaskManager
{

    public class Task
    {
        // Properties, using { get; set; } to make them auto-implemented properties
        // Properties need to begin with a capital letter
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task() { }

        public Task(string givenTitle, DateTime givenDueDate)
        {
            Id = Guid.NewGuid();
            Title = givenTitle;
            DueDate = givenDueDate;
            IsCompleted = false;
        }

    }
}