// Global using statements, geen dubbele using statements nodig in de code
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/global-usings
// Zet hier ALLEEN using statements die je in VEEL code files nodig hebt
global using System;
global using System.Linq;
using CSharpConsoleDemo;


// Top level statements, geen Main() nodig
// Wel beperkt tot 1 bestand per project (compilation-unit / assembly)
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements

Console.WriteLine("Hello, World!");

// Explicit type met object initializer syntax -->

Student explicitStudent = new Student { Nr = 1, FirstName = "Jan", LastName = "Janssens", DateOfBirth = new DateOnly(2000, 1, 1) };

// Implicit type -->
var implicitStudent = new Student();
implicitStudent.Nr = 2;
implicitStudent.FirstName = "Piet";
implicitStudent.LastName = "Pieters";
//implicitStudent.DateOfBirth = new DateOnly(2000, 1, 1); <-- kan niet, want init-only property

// Collection initializer -->
var students = new List<Student>() { 
    new Student { Nr = 1, FirstName = "Jan", LastName = "Janssens", DateOfBirth = new DateOnly(2000, 1, 1), }, 
    new Student { Nr = 2, FirstName = "Piet", LastName = "Pieters", },
    new Student { Nr = 3, FirstName = "Joris", LastName = "Jorissen", /*SlbTeacher = null <-- geen setter, kan alleen in constructor gezet worden */},
};


// null coalescing operator -->
students.Add(implicitStudent ?? explicitStudent);

// itereren over collectie (niet alle collecties zijn iterables, maar List<T> wel) -->
students.ForEach(s => Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}"));

// zelfde met foreach -->
foreach (var student in students)
{
    Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}"));
}