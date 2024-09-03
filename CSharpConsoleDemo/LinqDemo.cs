using Entities.Domain.Students;

namespace CSharpConsoleDemo;
public class LinqDemo
{
    public void Go(IEnumerable<Student> students)
    {
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

    }

}
