# Automation Framework Concept

Automation Framework project for UI test automation using Selenium and .NET core 3.1, the framework follows the Page Object Model pattern concepts.

**SUT:** [Booking.com](https://www.booking.com/)

## Requirements

* Chrome Browser
* [.NET Core 3.1](https://dotnet.microsoft.com/download)

## Configuration File

The configuration file is `appsettings.json`. It is located in **Kneat.Testcases** project.


```javascript
{
  "Browser": "Chrome",
  "ReportPath":  "/Users/<userName>/"
}
```

The Browser by default is Chrome and the ReportPath by default is the directory where the dlls are executed.
To set up the Report Path make sure that the user has write privileges.

## Usage

1. Clone the repository

```
$ git clone https://github.com/figuedmundo/kneat-automation-framework.git
```
2. Configure Report Path (Optional)

3. Build the projects

```
$ cd kneat-automation-framework
$ dotnet build
```

4. Execute the Test Cases

```
$ dotnet test Kneat.TestCases/Kneat.TestCases.csproj
```

5. Open the **AutomationReport.html** from the path specified.

6. Enjoy!
