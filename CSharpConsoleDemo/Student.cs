using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File-scoped namespace -->
namespace CSharpConsoleDemo;
public class Student : IStudent
{
    private bool _isEnlisted;

    public Student()
    {
        SlbTeacher = null;
    }
    public Student(Teacher? slbTeacher = null, int nr = 0, string firstName = "")
    {
        SlbTeacher = slbTeacher;
        Nr = nr;
        this.FirstName = firstName;

        Student student = new Student();
        student.Nr = 1;
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

    public int Test() => 1;
    
}
