using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestorankoAPI.Models;

public partial class RestoranMenagmentContext : DbContext
{
    public RestoranMenagmentContext()
    {
    }

    public RestoranMenagmentContext(DbContextOptions<RestoranMenagmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employment> Employments { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\SQLExpress2;Database=RestoranMenagment;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employment>(entity =>
        {
            entity.HasKey(e => e.Idemployment).HasName("PK__Employme__A434E6133EFB5815");

            entity.ToTable("Employment");

            entity.Property(e => e.Idemployment)
                .ValueGeneratedNever()
                .HasColumnName("IDEmployment");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Job).WithMany(p => p.Employments)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Employmen__JobID__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Employments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employmen__UserI__5070F446");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Idguest).HasName("PK__Guest__045D2BC241381A7D");

            entity.ToTable("Guest");

            entity.Property(e => e.Idguest)
                .ValueGeneratedNever()
                .HasColumnName("IDGuest");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Guests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Guest__UserID__4BAC3F29");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iditem).HasName("PK__Item__C9778A10CF204590");

            entity.ToTable("Item");

            entity.Property(e => e.Iditem)
                .ValueGeneratedNever()
                .HasColumnName("IDItem");
            entity.Property(e => e.BarmanId).HasColumnName("BarmanID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Barman).WithMany(p => p.Items)
                .HasForeignKey(d => d.BarmanId)
                .HasConstraintName("FK__Item__BarmanID__619B8048");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Item__OrderID__5FB337D6");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Item__ProductID__60A75C0F");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Idjob).HasName("PK__Job__9553E2248C2C90CA");

            entity.ToTable("Job");

            entity.Property(e => e.Idjob)
                .ValueGeneratedNever()
                .HasColumnName("IDJob");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("PK__Order__5CBBCADB87344B7F");

            entity.ToTable("Order");

            entity.Property(e => e.Idorder)
                .ValueGeneratedNever()
                .HasColumnName("IDOrder");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Waiter).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WaiterId)
                .HasConstraintName("FK__Order__WaiterID__5629CD9C");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("PK__Product__4290D1799EFD2584");

            entity.ToTable("Product");

            entity.Property(e => e.Idproduct)
                .ValueGeneratedNever()
                .HasColumnName("IDProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("PK__Reservat__53DF2D8DBF75C74D");

            entity.ToTable("Reservation");

            entity.Property(e => e.Idreservation)
                .ValueGeneratedNever()
                .HasColumnName("IDReservation");
            entity.Property(e => e.DateReservation).HasColumnType("datetime");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK__Reservati__Guest__5AEE82B9");

            entity.HasOne(d => d.Order).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Reservati__Order__59FA5E80");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__59063A47");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Idtable).HasName("PK__Table__72B3DFF4B24324BC");

            entity.ToTable("Table");

            entity.Property(e => e.Idtable)
                .ValueGeneratedNever()
                .HasColumnName("IDTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DF24FF5665");

            entity.ToTable("User");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("IDUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
