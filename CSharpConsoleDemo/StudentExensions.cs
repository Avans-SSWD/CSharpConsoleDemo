// Onnodige imports. Kan geen kwaad maar geeft ruis -->
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleDemo;

// Static class met extension method -->
public static class StudentExensions
{
    /// <summary>
    /// Extension method op Student
    /// (let op de 'this' en static)
    /// Expression bodied method ('=>')
    /// null-coalesce operator (??) 
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    public static string GetFullName(this Student student) => $"{student.FirstName} {student.Infix ?? ""} {student.LastName}";

    /// <summary>
    /// Nog een extension method, deze accepteerd een optionele extra parameter
    /// </summary>
    /// <param name="student"></param>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public static string AddPrefix(this Student student, string prefix = "") => 
        $"{prefix} {student.FirstName} {student.Infix ?? ""} {student.LastName}";

}
