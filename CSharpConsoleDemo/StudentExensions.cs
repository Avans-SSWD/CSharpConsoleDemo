using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleDemo;
public static class StudentExensions
{
    public static string GetFullName(this Student student) => $"{student.FirstName} {student.LastName}";

}
