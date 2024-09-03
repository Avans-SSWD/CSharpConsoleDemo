
using Entities.Domain.Staff;
using Entities.Domain.Students;

namespace CSharpConsoleDemo;
public class VariablesAndCollectionsDemo
{
    public IEnumerable<Student> Go()
    {
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

        // Na initialisatie een item toevoegen -->
        students.Add(new() { FirstName = "Sacharissa", LastName = "Cripslock" });
        
        // Meerdere toevoegen -->
        students.AddRange([explicitStudent, implicitStudent, studentRincewind]);

        // itereer over collectie -->
        foreach (var student in students)
        {
            // Extension method aanroep -->
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
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students[i]);
        }

        int cnt = 0;
        while (cnt < students.Count)
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

        return students;
    }
}
