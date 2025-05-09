# T-H-E
Build a simple console-based Task Manager application. Automate a login form using Selenium in C#. Logic Problem

## How to run the console-based Task Manager application:

### Prerequisites
- [.NET SDK, Version should not matter, but 7.0+ is recommended](https://dotnet.microsoft.com/en-us/download) 

### Run the App

- Open a terminal
- Navigate to the root of the project (directory containing the "T-H-E" folder)
- Run the following command: `dotnet run --project ./TaskManager/TaskManager.csproj`

The Task Manager console will shortly launch, and you can interact with it through the console

### Detail on commands

Some commands require the task ID to properly run. I recommend you first run the "view" command to acquire the task ID.

- "add": Inserts a task into your task list
- "edit": Edits a task in your task list, changing the title / due date
- "delete": Removes a task from your task list
- "complete": Marks a task from your list as completed
- "view": Returns a list of all tasks in your task list
- "filter": Asks for a filter property, then presents a list of all tasks in your task list that match the filter
- "exit": Exits the currently running program

Currently available filters:
- "completed": Shows tasks that have been completed
- "not completed": Shows tasks that have not been completed
- "due today": Shows tasks that are due today
- "due tomorrow": Shows tasks that are due tomorrow
- "overdue": Shows tasks that have not been completed and have a due date in the past

## How to run the Selenium Login Automation Tests:

### Prerequisites
- [.NET SDK, Version should not matter, but 7.0+ is recommended](https://dotnet.microsoft.com/en-us/download) 
- NUnit (For Unit Tests) You can install NUnit by running the following command in the project's root directory: `dotnet add package NUnit`
- Selenium (For Web Browser Automation) You can install Selenium by running the following command in the project's root directory: `dotnet add package Selenium.WebDriver`

### Run the Unit Tests

- Open a terminal
- Navigate to the root of the project (directory containing the "T-H-E" folder)
- From here, navigate to the SeleniumLoginAutomation directory (`cd SeleniumLoginAutomation`)
- Run the following command: `dotnet test`
- Screenshots from the test suite can be found in the SeleniumLoginAutomation/bin/Debug/net[YourNetVersion] folder (an example of net[YourNetVersion] could be net9.0)

## How to run TwoSum / TwoSum Unit Tests:

### Prerequisites
- [.NET SDK, Version should not matter, but 7.0+ is recommended](https://dotnet.microsoft.com/en-us/download) 
- NUnit (For the Unit Tests) You can install NUnit by running the following command in the project's root directory: `dotnet add package NUnit`

### How to run only the TwoSum console application:

- Open a terminal
- Navigate to the root of the project (directory containing the "T-H-E" folder)
- Run the following command: `dotnet run --project ./TwoSum/TwoSum.csproj`

The console will shortly launch and ask for your array values and then your target sum.

### Run the Unit Tests

- Open a terminal
- Navigate to the root of the project (directory containing the "T-H-E" folder)
- Run the following command: `dotnet test`