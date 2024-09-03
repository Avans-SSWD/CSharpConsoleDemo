// Global using statements, geen dubbele using statements nodig in de code
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/global-usings
// Zet hier ALLEEN using statements die je in VEEL code files nodig hebt
// (conventie is deze in apart cs bestand genaamd 'globalusings.cs' te zetten) -->
global using System;
global using System.Linq;

using CSharpConsoleDemo;


// Top level statements, geen Main() nodig
// Wel beperkt tot 1 bestand per project (compilation-unit / assembly) -->
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements

// Console IO -->
new ConsoleReadingWritingDemo().Go();


// Variables and collections -->
var students = new VariablesAndCollectionsDemo().Go();

// LINQ -->
new LinqDemo().Go(students);

// File IO -->
new FileIoDemo().Go(students);
