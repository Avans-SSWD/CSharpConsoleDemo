namespace CSharpConsoleDemo;
public class FileIoDemo
{
    public void Go(IEnumerable<Entities.Domain.Students.Student> students)
    {
        // File IO. Waar komt het bestand terecht? -->
        File.WriteAllLines("students.txt", students.Select(s => $"{s.Nr}\t{s.FirstName}\t{s.LastName}\r\n"));

        // string literals met interpolatie -->
        string dnaQuote = $@"In the beginning the Universe was created.
This had made many people very angry 
and has been widely regarded as a bad move.";
    }
}
