
namespace CSharpConsoleDemo;
public class ConsoleReadingWritingDemo
{
    public void Go()
    {
        Console.WriteLine("The answer to the question of Life, The Universe and Everything?");
        var answer = Console.ReadLine();
        //int answerAsInt2 = int.Parse(answer);

        if (!int.TryParse(answer, out int answerAsInt))
        {
            Console.WriteLine("It is a number...");
        }
        else if (answerAsInt == 42)
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
    }
}
