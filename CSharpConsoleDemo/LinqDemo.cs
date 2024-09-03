using Entities.Domain.Students;

namespace CSharpConsoleDemo;
public class LinqDemo
{
    public void Go(IEnumerable<Student> students)
    {

        Func<int, int> squareInt = x => x * x;
        Func<int, int, string> multiplyTwoInts = (x,y) => $"{x} * {y} is {x * y}";

        var squared = squareInt(5);
        var multiplied = multiplyTwoInts(5, 6);

        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/formatting-types
        Console.WriteLine($"5 squared is {squared}. 5x6 is {multiplied:D}");

        // query syntax -->
        var studentsWithJ_QS =
            from student in students
            where student.FirstName.StartsWith("J")
            select student;

        // method syntax -->
        var studentsWithS_MS = students
            .Where(s => s.FirstName.Contains("S", StringComparison.InvariantCultureIgnoreCase));


        // operaties -->
        // Union -->
        var uniqueStudents = studentsWithJ_QS.Union(studentsWithS_MS);

        // intersect, items die in beide collecties zitten
        // maar waarom geen resultaat?
        // (IEqualityComparer om zelf te sturen hoe vergeleken moet worden)-->
        var eenIntersect = studentsWithJ_QS.Intersect(studentsWithS_MS);
        var eenTweedeCollectie = new List<Student>()
        {
            new Student { Nr = 4, FirstName = "Mustrum", LastName = "Ridcully", },
            new Student { Nr = 5, FirstName = "Rincewind", LastName = "The Wizard", },
            new Student { Nr = 6, FirstName = "Bloody Stupid", LastName = "Johnson", },
        };

        // Anoniem type (hoover erover voor intellisense) -->
        var iets = new { FirstValue = "een waarde", SecondValue = "een tweede waarde", AnInteger = 42 };
        Console.WriteLine($"{iets.FirstValue}");

        try
        {
            var bestaatNiet = eenTweedeCollectie.Single(s => s.FirstName == "Bestaat niet");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Oepsie: {ex.Message}.\r\n\r\nStacktrace: {ex.StackTrace}");
        }

        // nog een keer, maar dan met default value -->
        var bestaatNiet2 = eenTweedeCollectie.SingleOrDefault(s => s.FirstName == "Bestaat niet");
        if (bestaatNiet2 == null)
        {
            Console.WriteLine("Mustrum2 is null");
        }

        try
        {
            var kanNietWantWeEisenMaar1 = eenTweedeCollectie.Single(s => s != null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Oepsie: {ex.Message}");
        }

        var kanWelWantPaktDeEerste = eenTweedeCollectie.FirstOrDefault(s => s != null);

        // transformaties mbv select -->
        // fluent syntax, method chaining -->
        eenTweedeCollectie
            .Where(s => s.LastName.Contains("i", StringComparison.OrdinalIgnoreCase)) // <-- filter, case insensitive
            .Select(s => new { s.Nr, s.FirstName, s.LastName }) // <-- transformatie naar anoniem type
            .ToList() // <-- materialize view (ie: vul geheugen)
            .ForEach(s => Console.WriteLine($"{s.Nr} {s.FirstName} {s.LastName}")); // <-- itereren over collectie

    }

}
