using System;
using System.Collections.Generic;

namespace ProductAPIEFCore.Model;

public partial class Student
{
    public string Stid { get; set; } = null!;

    public string? Stname { get; set; }

    public double? Marks { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public bool? Result { get; set; }
}
