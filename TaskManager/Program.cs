namespace TaskManager;

class TaskManager
{
    private readonly JsonTaskStorage jsonTaskStorage;
    private List<Task> tasks;

    public TaskManager(JsonTaskStorage jsonTaskStorage)
    {
        this.jsonTaskStorage = jsonTaskStorage;
        tasks = jsonTaskStorage.LoadTasks() ?? [];
    }
    public void AddTask(string title, DateTime dueDate)
    {
        Task newTask = new(title, dueDate);
        tasks.Add(newTask);
        jsonTaskStorage.SaveTasks(tasks);
    }

    public void EditTask(Guid id, string newTitle, DateTime newDueDate)
    {
        Task? findTask = tasks.FirstOrDefault(t => t.Id == id);
        if (findTask != null)
        {
            findTask.Title = newTitle;
            findTask.DueDate = newDueDate;
            jsonTaskStorage.SaveTasks(tasks);
        }
    }

    public void DeleteTask(Guid id)
    {
        Task? findTask = tasks.FirstOrDefault(t => t.Id == id);
        if (findTask != null)
        {
            tasks.Remove(findTask);
            jsonTaskStorage.SaveTasks(tasks);
        }
    }

    public void CompleteTask(Guid id)
    {
        Task? findTask = tasks.FirstOrDefault(t => t.Id == id);
        if (findTask != null)
        {
            findTask.IsCompleted = true;
            jsonTaskStorage.SaveTasks(tasks);
        }
    }

    public void ViewAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due Date: {task.DueDate}, Completed: {task.IsCompleted}");
        }
    }

    public void FilterTasks(string? filter)
    {
        if (string.IsNullOrEmpty(filter))
        {
            Console.WriteLine("No filter provided. Presenting all tasks.");
            ViewAllTasks();
            return;
        }

        filter = filter.ToLower();

        IEnumerable<Task> filteredTasks = tasks;

        switch (filter)
        {
            case "completed":
                filteredTasks = tasks.Where(t => t.IsCompleted);
                Console.WriteLine("Presenting tasks with filter: completed.");
                break;
            case "not completed":
                filteredTasks = tasks.Where(t => !t.IsCompleted);
                Console.WriteLine("Presenting tasks with filter: not completed.");
                break;
            case "due today":
                filteredTasks = tasks.Where(t => t.DueDate.Date == DateTime.Now.Date && !t.IsCompleted);
                Console.WriteLine("Presenting tasks with filter: due today.");
                break;
            case "due tomorrow":
                filteredTasks = tasks.Where(t => t.DueDate.Date == DateTime.Now.AddDays(1).Date && !t.IsCompleted);
                Console.WriteLine("Presenting tasks with filter: due tomorrow.");
                break;
            case "overdue":
                filteredTasks = tasks.Where(t => t.DueDate < DateTime.Now && !t.IsCompleted);
                Console.WriteLine("Presenting tasks with filter: overdue.");
                break;
            default:
                Console.WriteLine("There is no implementation for this filter yet or it is invalid. Presenting all tasks instead.");
                break;
        }

        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due Date: {task.DueDate}, Completed: {task.IsCompleted}");
        }
    }

    static void Main(string[] args)
    {
        JsonTaskStorage storage = new JsonTaskStorage();
        TaskManager taskManager = new TaskManager(storage);
        string command = string.Empty;

        while (command != "exit")
        {
            Console.WriteLine("Enter a command (add, edit, delete, complete, view, filter, exit):");
            command = Console.ReadLine()?.ToLower() ?? string.Empty;

            switch (command)
            {
                case "add":
                    Console.WriteLine("Enter task title:");
                    string? title = Console.ReadLine();
                    if (string.IsNullOrEmpty(title))
                    {
                        Console.WriteLine("Title cannot be empty. Please try again.");
                        break;
                    }
                    Console.WriteLine("Enter due date (yyyy-mm-dd):");
                    string? dateInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(dateInput) || !DateTime.TryParse(dateInput, out DateTime dueDate))
                    {
                        Console.WriteLine("Date must be valid or cannot be empty. Please try again.");
                        break;
                    }
                    taskManager.AddTask(title, dueDate);
                    break;
                case "edit":
                    Console.WriteLine("Enter task ID to edit:");
                    string? guidInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(guidInput) || !Guid.TryParse(guidInput, out Guid idToEdit))
                    {
                        Console.WriteLine("Task ID must be valid or cannot be empty. Please try again.");
                        break;
                    }
                    Console.WriteLine("Enter new title:");
                    string? newTitle = Console.ReadLine();
                    if (string.IsNullOrEmpty(newTitle))
                    {
                        Console.WriteLine("Title cannot be empty. Please try again.");
                        break;
                    }
                    Console.WriteLine("Enter new due date (yyyy-mm-dd):");
                    string? newDateInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(newDateInput) || !DateTime.TryParse(newDateInput, out DateTime newDueDate))
                    {
                        Console.WriteLine("Date must be valid or cannot be empty. Please try again.");
                        break;
                    }
                    taskManager.EditTask(idToEdit, newTitle, newDueDate);
                    break;
                case "delete":
                    Console.WriteLine("Enter task ID to delete:");
                    string? deleteGuidInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(deleteGuidInput) || !Guid.TryParse(deleteGuidInput, out Guid idToDelete))
                    {
                        Console.WriteLine("Task ID must be valid or cannot be empty. Please try again.");
                        break;
                    }
                    taskManager.DeleteTask(idToDelete);
                    break;
                case "complete":
                    Console.WriteLine("Enter task ID to mark as complete:");
                    string? completeGuidInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(completeGuidInput) || !Guid.TryParse(completeGuidInput, out Guid idToComplete))
                    {
                        Console.WriteLine("Task ID must be valid or cannot be empty. Please try again.");
                        break;
                    }
                    taskManager.CompleteTask(idToComplete);
                    break;
                case "view":
                    taskManager.ViewAllTasks();
                    break;
                case "filter":
                    Console.WriteLine("Enter filter criteria (e.g., completed, not completed, due today, due tomorrow, overdue):");
                    string? filterCriteria = Console.ReadLine();
                    if (string.IsNullOrEmpty(filterCriteria))
                    {
                        Console.WriteLine("Filter is empty. Presenting all tasks.");
                        taskManager.ViewAllTasks();
                        break;
                    }
                    taskManager.FilterTasks(filterCriteria);
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }

}