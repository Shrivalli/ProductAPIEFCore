﻿using System;
using System.Collections.Generic;

namespace ProductAPIEFCore.Model;

public partial class Product
{
    public int Pid { get; set; }

    public string Pname { get; set; } = null!;

    public int? Price { get; set; }

    public int? Qty { get; set; }

    public DateTime? Dom { get; set; }

    public Product() { }

    public Product(int Pid,string Pname,int Price)
    {
        this.Pid = Pid;
        this.Pname = Pname;
        this.Price = Price;    

    }

    
}
