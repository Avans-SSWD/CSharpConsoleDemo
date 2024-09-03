// Global using statements, geen dubbele using statements nodig in de code
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/global-usings
// Zet hier ALLEEN using statements die je in VEEL code files nodig hebt
// (conventie is deze in apart cs bestand genaamd 'globalusings.cs' te zetten) -->
global using System;
global using System.Linq;

using CSharpConsoleDemo;
using Entities.Domain.Staff;
using Entities.Domain.Students;


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

Student explicitStudent = new Entities.Domain.Students.Student 
{ 
    Nr = 1, 
    FirstName = "Twoflower", 
    LastName = "The Tourist", 
    DateOfBirth = new DateOnly(2000, 1, 1) // <-- DateOfBirth kan alleen hier gezet worden (init-only property)
};

//explicitStudent.DateOfBirth = new DateOnly(2000, 1, 1); // <-- kan niet, want init-only property

// Implicit type -->
var implicitStudent = new Student() { FirstName = "Ponder" };
implicitStudent.Nr = 2;
implicitStudent.LastName = "Stibbons";
//implicitStudent.DateOfBirth = new DateOnly(2000, 1, 1); <-- kan niet, want init-only property

// Hier kan DateOfBirth wel gezet worden (object initializer syntax) -->
// Gebruikt 'target-typed new' syntax  (kan niet icm 'var' aka implicit type)-->
Student studentRincewind = new(new Teacher(), 1, "Rincewind")
{
    DateOfBirth = new DateOnly(2001, 5, 11)
};


// Collection initializer -->
var students = new List<Student>() 
{ 
    new Student { Nr = 1, FirstName = "Cohen", LastName = "The Barbarian", DateOfBirth = new DateOnly(2000, 1, 1), }, 
    new Student { Nr = 2, FirstName = "Cut-Me-Own-Throat", LastName = "Dibbler", },
    new() { Nr = 3, FirstName = "Julliet", LastName = "Stollop", /*SlbTeacher = null <-- geen setter, kan alleen in constructor gezet worden */},
};


// itereer over collectie -->
foreach (var student in students)
{
    // Extension method -->
    Console.WriteLine(student.GetFullName());
}


implicitStudent = null;

// null coalescing operator, explicitStudent wordt toegevoegd want implicitStudent is null -->
students.Add(implicitStudent ?? explicitStudent);

// itereren over collectie (niet alle collecties zijn iterables, maar List<T> wel) -->
// gebruikt lambda expressie (s => ...) -->
students.ForEach(s => Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}"));

// zelfde met foreach -->
foreach (var student in students)
{
    Console.WriteLine($"{student.Nr} {0:c} {student.FirstName} {student.LastName}");
    Console.WriteLine("{0} {1}", student.Nr, student.FirstName);
}

// index-based loops, meestal is foreach duidelijker -->
for (int i =0; i < students.Count; i++)
{
    Console.WriteLine(students[i]);    
}

int cnt = 0;
while(cnt < students.Count)
{
    // post-increment (ophogen NA moment van gebruik) -->
    Console.WriteLine(students[cnt++]);
}

cnt = 0;
do
{
    // pre-increment (ophogen VOOR moment van gebruik) -->
    Console.WriteLine(students[cnt]);
} // Bij fout geeft dit de klassieke off-by-one error -->
while (++cnt < students.Count);

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
