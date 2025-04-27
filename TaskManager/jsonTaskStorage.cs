using System.Text.Json;

namespace TaskManager
{
    public class JsonTaskStorage
    {
        private string filePath;
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public JsonTaskStorage(string? givenFilePath = null)
        {

            // If we weren't given a path, we create a default one in the current directory
            if (string.IsNullOrEmpty(givenFilePath))
            {
                givenFilePath = Path.Combine(Environment.CurrentDirectory, "tasks.json");
            }

            filePath = givenFilePath;

            //Ensure the file itself exists. If it doesn't, create it with an empty array
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }

        // Serializes the list of Tasks into a jsonfile
        public void SaveTasks(List<Task> tasks)
        {
            string jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Reads all text from the jsonFile and deserializes it into a list of Tasks
        public List<Task> LoadTasks()
        {
            if (!File.Exists(filePath))
            {
                return new List<Task>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Task>>(jsonString, options) ?? new List<Task>();
        }
    }
}