﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductAPIEFCore.Model;

public partial class BirlasoftdbContext : DbContext
{
    public BirlasoftdbContext()
    {
    }

    public BirlasoftdbContext(DbContextOptions<BirlasoftdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sample> Samples { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Usertbl> Usertbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Birlasoftdb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__employee__AF4CE8651E7F2EAB");

            entity.ToTable("employee");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Did).HasColumnName("did");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Empname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Phno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phno");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.DidNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Did)
                .HasConstraintName("FK__employee__did__267ABA7A");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__product__DD37D91A47973B1A");

            entity.ToTable("product");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("pid");
            entity.Property(e => e.Dom)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("dom");
            entity.Property(e => e.Pname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pname");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
        });

        modelBuilder.Entity<Sample>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__sample__DDDFDD361ADD58CA");

            entity.ToTable("sample");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Doj)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("doj");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Stid).HasName("PK__student__312D1FC7CF281DB8");

            entity.ToTable("student");

            entity.Property(e => e.Stid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("stid");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.Stname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("stname");
        });

        modelBuilder.Entity<Usertbl>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Usertbl__AB6E61653A14B5D4");

            entity.ToTable("Usertbl");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pwd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
