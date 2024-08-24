# GitHub Project Analyzer

**GitHubAnalyzer** is a simple WPF (Windows Presentation Foundation) application that allows users to analyze/scan a specific directory structure and convert found C# source code files (`.cs`) into a JSON format. The result of the analysis is a JSON file that contains the names, relative paths, and contents of all discovered `.cs` files.

## Key Features
- **Folder Selection:** Users can select a folder, and the application will recursively search for `.cs` files within that directory.
- **Analysis and Conversion:** The application reads the contents of the discovered `.cs` files and compiles them into a JSON format. The JSON includes the file name, relative path, and full content of each file.
- **Result Saving:** After the analysis, users can specify where they want to save the generated JSON file.

## Usage
1. **Select a Folder:** Choose the folder you want to analyze by clicking the "Select Folder" button.
2. **Start the Analysis:** Click the "Start Analysis" button to begin scanning the folder for `.cs` files.
3. **Review the Results:** The application will scan the folder, read, and compile all `.cs` files into a JSON representation.
4. **Save the JSON File:** Save the generated JSON file to your desired location by specifying the path in the save dialog.

## Development Environment
- **Language:** C#
- **Technology:** WPF (.NET Framework)
- **External Libraries:** [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) for JSON conversion

## Installation
To run this project, clone the repository and open the solution in Visual Studio. Make sure to restore NuGet packages, especially `Newtonsoft.Json`.
