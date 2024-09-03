namespace Entities.Domain.Interfaces;

public interface IStudent
{
    // Een interface geeft geen access modifiers nodig (kan wel maar is overbodig)
    // Het is mogelijk een default implementatie in een interface te stoppen maar dit gaan we NIET gebruiken
    // Alle types die deze interface implementeren moeten de members van de interface implementeren,
    // OOK als de interface methods / properties heeft die het type eigenlijk niet nodig heeft.

    DateOnly DateOfBirth { get; init; }
    string FirstName { get; set; }
    int Nr { get; set; }

    int Test();
}