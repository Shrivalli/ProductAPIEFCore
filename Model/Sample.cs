﻿using System;
using System.Collections.Generic;

namespace ProductAPIEFCore.Model;

public partial class Sample
{
    public int Sid { get; set; }

    public string? Sname { get; set; }

    public DateTime? Doj { get; set; }
}
