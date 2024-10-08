﻿using Entities.Domain.Interfaces;
using Entities.Domain.Staff;
using System.Diagnostics.CodeAnalysis;

// File-scoped namespace -->
namespace Entities.Domain.Students;
public class Student : IStudent
{
    private bool _isEnlisted;

    public Student()
    {

        SlbTeacher = null;
    }

    // annotatie (attribuut) geeft aan dat 'required' members hier gezet worden -->
    [SetsRequiredMembers]
    public Student(Teacher? slbTeacher = null, int nr = 0, string firstName = "")
    {
        SlbTeacher = slbTeacher;
        Nr = nr;
        FirstName = firstName;

        // MOET FirstName zetten wegens 'required' -->
        Student student = new Student() { FirstName = firstName };
        student.Nr = 1;
    }

    public int Nr { get; set; }

    // Reference type, mag eigenlijk niet null zijn -->
    // Juiste manier: required modifier
    public required string FirstName { get; set; }

    // Nullable reference type, mag wel null zijn -->
    public string? Infix { get; set; } = null; // = null is niet nodig, default zijn ref types null.

    // Reference type, mag eigenlijk niet null zijn -->
    // Niet gebruiken, lelijk: override warning met !
    public string LastName { get; set; } = null!;

    // init-only property, kan alleen in constructor EN via object initialization gezet worden -->
    public DateOnly DateOfBirth { get; init; }

    // read-only property, kan alleen in constructor gezet worden -->
    public Teacher? SlbTeacher { get; }

    // Een full-property met backing field -->
    public bool IsEnlisted { get => _isEnlisted; set => _isEnlisted = value; }

    // Een calculated full-property met implementatie -->
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - DateOfBirth.Year;
            if (age < 0)
            {
                throw new InvalidOperationException("Invalid age");
            }
            return age;
        }
    }

    // Expression-bodied method -->
    public int Test() => 1;

}
