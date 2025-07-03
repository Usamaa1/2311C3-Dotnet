using System;
using System.Collections.Generic;

namespace BasicsWithDBProject.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? StudentClass { get; set; }

    public int? StudentAge { get; set; }
}
