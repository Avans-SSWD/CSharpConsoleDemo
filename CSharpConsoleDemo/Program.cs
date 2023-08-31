// Global using statements, geen dubbele using statements nodig in de code
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/global-usings
// Zet hier ALLEEN using statements die je in VEEL code files nodig hebt
// (conventie is deze in apart cs bestand genaamd 'globalusings.cs' te zetten) -->
global using System;
global using System.Linq;
using CSharpConsoleDemo;
using System.IO.Pipes;


// Top level statements, geen Main() nodig
// Wel beperkt tot 1 bestand per project (compilation-unit / assembly) -->
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements

Console.WriteLine("The answer to the question of Life, The Universe and Everything?");
var answer = Console.ReadLine();
//int answerAsInt2 = int.Parse(answer);

if (!int.TryParse(answer, out int answerAsInt))
{
    Console.WriteLine("It is a number...");
}
else if( answerAsInt == 42)
{
    Console.WriteLine("Correct!");
}
else
{
    Console.WriteLine("Wrong!");
}

// Pattern matching -->
var result = answer switch 
{
    string s when s.Length > 2 => "String length is greater then 2, Wrong...", // <-- 
    string s when int.TryParse(s, out int i) && i == 42 => "Correct!", // <-- probeer 'anwer te parsen als int en controleer waarde
    "42" => "Correct!", // <-- match als string (zal niet geraakt worden want vorige case matcht ook)
    _ => "Wrong!", // <-- default met discard pattern
};



// Explicit type met object initializer syntax -->

Student explicitStudent = new Student 
{ 
    Nr = 1, FirstName = "Twoflower", LastName = "The Tourist", DateOfBirth = new DateOnly(2000, 1, 1) // <-- DateOfBirth kan hier want 6initialiseren
};

//explicitStudent.DateOfBirth = new DateOnly(2000, 1, 1); // <-- kan niet, want init-only property

// Implicit type -->
var implicitStudent = new Student();
implicitStudent.Nr = 2;
implicitStudent.FirstName = "Ponder";
implicitStudent.LastName = "Stibbons";
//implicitStudent.DateOfBirth = new DateOnly(2000, 1, 1); <-- kan niet, want init-only property

//Student student = new Student(new Teacher(), 1, "blabla");



// Collection initializer -->
var students = new List<Student>() { 
    new Student { Nr = 1, FirstName = "Cohen", LastName = "The Barbarian", DateOfBirth = new DateOnly(2000, 1, 1), }, 
    new Student { Nr = 2, FirstName = "Cut-Me-Own-Throat", LastName = "Dibbler", },
    new Student { Nr = 3, FirstName = "Julliet", LastName = "Stollop", /*SlbTeacher = null <-- geen setter, kan alleen in constructor gezet worden */},
};


// Extension method -->
foreach(var student in students)
{
    Console.WriteLine(student.GetFullName());
}


// null coalescing operator -->
students.Add(implicitStudent ?? explicitStudent);

// itereren over collectie (niet alle collecties zijn iterables, maar List<T> wel) -->
students.ForEach(s => Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}"));

// zelfde met foreach -->
foreach (var student in students)
{
    Console.WriteLine($"{student.Nr} {0:c} {student.FirstName} {student.LastName}");
    Console.WriteLine("{0} {1}", student.Nr, student.FirstName);
}

for (int i =0; i < students.Count; i++)
{
    Console.WriteLine(students[i]);    
}


// LINQ -->

// query syntax -->
var studentsWithJ_QS =
    from student in students
    where student.FirstName.StartsWith("J")
    select student;

// method syntax -->
var studentsWithS_MS = students
    .Where(s => s.FirstName.Contains("S", StringComparison.InvariantCultureIgnoreCase));


// operaties -->
var eenUnion = studentsWithJ_QS.Union(studentsWithS_MS);

var eenTweedeCollectie = new List<Student>()
{
    new Student { Nr = 4, FirstName = "Mustrum", LastName = "Ridcully", },
    new Student { Nr = 5, FirstName = "Rincewind", LastName = "The Wizard", },
    new Student { Nr = 6, FirstName = "Bloody Stupid", LastName = "Johnson", },
};

// transformaties mbv select -->
// fluent syntax, method chaining -->
eenTweedeCollectie
    .Where(s => s.LastName.Contains("i", StringComparison.OrdinalIgnoreCase)) // <-- filter, case insensitive
    .Select(s => new { s.Nr, s.FirstName, s.LastName }) // <-- transformatie naar anoniem type
    .ToList() // <-- materialize view (ie: vul geheugen)
    .ForEach(s => Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}")); // <-- itereren over collectie


// File IO
File.WriteAllLines("students.txt", students.Select(s => $"{s.Nr}\t{s.FirstName}\t{s.LastName}\r\n"));

// string literals met interpolatie -->
string dnaQuote = $@"In the beginning the Universe was created.
This had made many people very angry 
and has been widely regarded as a bad move.";
