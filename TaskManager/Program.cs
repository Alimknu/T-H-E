namespace TaskManager;

class TaskManager
{
    JsonTaskStorage jsonTaskStorage;
    List<Task> tasks;

    public TaskManager(string filePath = null)
    {
        jsonTaskStorage = new JsonTaskStorage(filePath);
        tasks = jsonTaskStorage.loadTasks();
    }
    public void addTask(string title, DateTime dueDate)
    {
        Task newTask = new Task(title, dueDate);
        tasks.Add(newTask);
        jsonTaskStorage.saveTasks(tasks);
    }

    public void editTask(Guid id, string newTitle, DateTime newDueDate)
    {
        Task findTask = tasks.FirstOrDefault(t => t.id == id);
        if (findTask != null)
        {
            findTask.title = newTitle;
            findTask.dueDate = newDueDate;
            jsonTaskStorage.saveTasks(tasks);
        }
    }

    public void deleteTask(Guid id)
    {
        Task findTask = tasks.FirstOrDefault(t => t.id == id);
        if (findTask != null)
        {
            tasks.Remove(findTask);
            jsonTaskStorage.saveTasks(tasks);
        }
    }

    public void completeTask(Guid id)
    {
        Task findTask = tasks.FirstOrDefault(t => t.id == id);
        if (findTask != null)
        {
            findTask.isCompleted = true;
            jsonTaskStorage.saveTasks(tasks);
        }
    }

    public void viewAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.id}, Title: {task.title}, Due Date: {task.dueDate}, Completed: {task.isCompleted}");
        }
    }

    public void filterTasks(string filter)
    {
        filter = filter.ToLower();
        if (string.IsNullOrEmpty(filter))
        {
            Console.WriteLine("No filter provided. Presenting all tasks.");
            viewAllTasks();
            return;
        }

        IEnumerable<Task> filteredTasks = tasks;

        switch (filter)
        {
            case "completed":
                filteredTasks = tasks.Where(t => t.isCompleted);
                Console.WriteLine("Presenting tasks with filter: completed.");
                break;
            case "not completed":
                filteredTasks = tasks.Where(t => !t.isCompleted);
                Console.WriteLine("Presenting tasks with filter: not completed.");
                break;
            case "due today":
                filteredTasks = tasks.Where(t => t.dueDate.Date == DateTime.Now.Date && !t.isCompleted);
                Console.WriteLine("Presenting tasks with filter: due today.");
                break;
            case "due tomorrow":
                filteredTasks = tasks.Where(t => t.dueDate.Date == DateTime.Now.AddDays(1).Date && !t.isCompleted);
                Console.WriteLine("Presenting tasks with filter: due tomorrow.");
                break;
            case "overdue":
                filteredTasks = tasks.Where(t => t.dueDate < DateTime.Now && !t.isCompleted);
                Console.WriteLine("Presenting tasks with filter: overdue.");
                break;
            default:
                Console.WriteLine("There is no implementation for this filter yet or it is invalid. Presenting all tasks instead.");
                break;
        }

        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.id}, Title: {task.title}, Due Date: {task.dueDate}, Completed: {task.isCompleted}");
        }
    }

    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        string command = string.Empty;

        while (command != "exit")
        {
            Console.WriteLine("Enter a command (add, edit, delete, complete, view, filter, exit):");
            command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "add":
                    Console.WriteLine("Enter task title:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter due date (yyyy-mm-dd):");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());
                    taskManager.addTask(title, dueDate);
                    break;
                case "edit":
                    Console.WriteLine("Enter task ID to edit:");
                    Guid idToEdit = Guid.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new title:");
                    string newTitle = Console.ReadLine();
                    Console.WriteLine("Enter new due date (yyyy-mm-dd):");
                    DateTime newDueDate = DateTime.Parse(Console.ReadLine());
                    taskManager.editTask(idToEdit, newTitle, newDueDate);
                    break;
                case "delete":
                    Console.WriteLine("Enter task ID to delete:");
                    Guid idToDelete = Guid.Parse(Console.ReadLine());
                    taskManager.deleteTask(idToDelete);
                    break;
                case "complete":
                    Console.WriteLine("Enter task ID to mark as complete:");
                    Guid idToComplete = Guid.Parse(Console.ReadLine());
                    taskManager.completeTask(idToComplete);
                    break;
                case "view":
                    taskManager.viewAllTasks();
                    break;
                case "filter":
                    Console.WriteLine("Enter filter criteria (e.g., completed, not completed, due today, due tomorrow, overdue):");
                    string filterCriteria = Console.ReadLine().ToLower();
                    taskManager.filterTasks(filterCriteria);
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