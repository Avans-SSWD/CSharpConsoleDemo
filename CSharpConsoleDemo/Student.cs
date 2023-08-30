using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File-scoped namespace -->
namespace CSharpConsoleDemo;
public class Student
{
    private bool _isEnlisted;

    public Student()
    {
        
    }
    public Student(Teacher? slbTeacher = null)
    {
        SlbTeacher = slbTeacher;
    }

    public int Nr { get; set; }
    
    // Reference type, mag niet null zijn -->
    public string FirstName { get; set; } = null!;
    
    // Nullable reference type, mag wel null zijn -->
    public string? LastName { get; set; } = null; // = null is niet nodig, default zijn ref types null.

    // init-only property, kan alleen in constructor EN via object initialization gezet worden -->
    public DateOnly DateOfBirth { get; init; }

    // read-only property, kan alleen in constructor gezet worden -->
    public Teacher? SlbTeacher { get; }


    // Een full-property met backing field -->
    public bool IsEnlisted { get => _isEnlisted; set => _isEnlisted = value; }
}
