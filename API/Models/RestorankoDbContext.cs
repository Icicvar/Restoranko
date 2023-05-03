using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class RestorankoDbContext : DbContext
{
    public RestorankoDbContext()
    {
    }

    public RestorankoDbContext(DbContextOptions<RestorankoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:RestorankoConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Idguest).HasName("PK__Guest__045D2BC2879CD39D");

            entity.ToTable("Guest");

            entity.Property(e => e.Idguest).HasColumnName("IDGuest");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Guests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Guest__UserID__5165187F");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iditem).HasName("PK__Item__C9778A1098DE3303");

            entity.ToTable("Item");

            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Job).WithMany(p => p.Items)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Item__JobID__60A75C0F");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Item__OrderID__628FA481");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Item__ProductID__619B8048");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Idjob).HasName("PK__Job__9553E224D0EF1252");

            entity.ToTable("Job");

            entity.Property(e => e.Idjob).HasColumnName("IDJob");
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Job__JobTypeID__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Job__UserID__4D94879B");

            entity.HasMany(d => d.JobTypes).WithMany(p => p.JobsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "JobJobType",
                    r => r.HasOne<JobType>().WithMany()
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Job_JobTy__JobTy__66603565"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Job_JobTy__JobID__656C112C"),
                    j =>
                    {
                        j.HasKey("JobId", "JobTypeId").HasName("PK__Job_JobT__CB79D6C62F9D8CD8");
                        j.ToTable("Job_JobType");
                        j.IndexerProperty<int>("JobId").HasColumnName("JobID");
                        j.IndexerProperty<int>("JobTypeId").HasColumnName("JobTypeID");
                    });
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.IdjobType).HasName("PK__JobType__40FBA95641C88A0C");

            entity.ToTable("JobType");

            entity.Property(e => e.IdjobType).HasColumnName("IDJobType");
            entity.Property(e => e.JobTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("PK__Order__5CBBCADBC3502D97");

            entity.ToTable("Order");

            entity.Property(e => e.Idorder).HasColumnName("IDOrder");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Waiter).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WaiterId)
                .HasConstraintName("FK__Order__WaiterID__5629CD9C");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("PK__Product__4290D17931B995F1");

            entity.ToTable("Product");

            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Orders).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductOrder",
                    r => r.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Product_O__Order__6E01572D"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Product_O__Produ__6D0D32F4"),
                    j =>
                    {
                        j.HasKey("ProductId", "OrderId").HasName("PK__Product___5835C357B23ABE22");
                        j.ToTable("Product_Order");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("OrderID");
                    });
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("PK__Reservat__53DF2D8D9827600D");

            entity.ToTable("Reservation");

            entity.Property(e => e.Idreservation).HasColumnName("IDReservation");
            entity.Property(e => e.DateReservation).HasColumnType("datetime");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK__Reservati__Guest__5AEE82B9");

            entity.HasOne(d => d.Order).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Reservati__Order__59FA5E80");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reservati__UserI__5BE2A6F2");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Idtable).HasName("PK__Table__72B3DFF4F2945BF7");

            entity.ToTable("Table");

            entity.Property(e => e.Idtable).HasColumnName("IDTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DF868B8F36");

            entity.ToTable("User");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
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

            entity.HasMany(d => d.GuestsNavigation).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGuest",
                    r => r.HasOne<Guest>().WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Gues__Guest__6A30C649"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Gues__UserI__693CA210"),
                    j =>
                    {
                        j.HasKey("UserId", "GuestId").HasName("PK__User_Gue__274CEF6F34ACC4C8");
                        j.ToTable("User_Guest");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("GuestId").HasColumnName("GuestID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
