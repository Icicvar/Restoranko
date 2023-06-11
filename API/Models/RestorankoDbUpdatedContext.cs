using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class RestorankoDbUpdatedContext : DbContext
{
    public RestorankoDbUpdatedContext()
    {
    }

    public RestorankoDbUpdatedContext(DbContextOptions<RestorankoDbUpdatedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductTime> ProductTimes { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public  DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ConnectionStrings:RestorankoConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB27AA01CA82B");

            entity.ToTable("Ingredient");

            entity.Property(e => e.IngredientId)
                .ValueGeneratedNever()
                .HasColumnName("IngredientID");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iditem).HasName("PK__Item__C9778A1027AB4AAF");

            entity.ToTable("Item");

            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.EmpolyeeId).HasColumnName("EmpolyeeID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Empolyee).WithMany(p => p.Items)
                .HasForeignKey(d => d.EmpolyeeId)
                .HasConstraintName("FK__Item__EmpolyeeID__5535A963");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Item__OrderID__571DF1D5");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Item__ProductID__5629CD9C");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("PK__Order__5CBBCADB68D84176");

            entity.ToTable("Order");

            entity.Property(e => e.Idorder).HasColumnName("IDOrder");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Waiter).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WaiterId)
                .HasConstraintName("FK__Order__WaiterID__3E52440B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("PK__Product__4290D179C3862B7F");

            entity.ToTable("Product");

            entity.Property(e => e.Idproduct).HasColumnName("IDProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RecepieId).HasColumnName("RecepieID");

            entity.HasOne(d => d.Recepie).WithMany(p => p.Products)
                .HasForeignKey(d => d.RecepieId)
                .HasConstraintName("FK__Product__Recepie__52593CB8");
        });

        modelBuilder.Entity<ProductTime>(entity =>
        {
            entity.HasKey(e => e.IdproductTime).HasName("PK__ProductT__2719F40CF5981FF0");

            entity.ToTable("ProductTime");

            entity.Property(e => e.IdproductTime).HasColumnName("IDProductTime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Item).WithMany(p => p.ProductTimes)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTime_Product");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductTimes)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTime_Order");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Idrecipe).HasName("PK__Recipe__9818D75AA8CAFD44");

            entity.ToTable("Recipe");

            entity.Property(e => e.Idrecipe)
                .ValueGeneratedNever()
                .HasColumnName("IDRecipe");
            entity.Property(e => e.RecipeDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RecipeImage).IsUnicode(false);
            entity.Property(e => e.RecipeInstructions).IsUnicode(false);
            entity.Property(e => e.RecipeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId }).HasName("PK__RecipeIn__463363F7B089DEA7");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeIng__Ingre__4F7CD00D");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeIng__Recip__4E88ABD4");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("PK__Reservat__53DF2D8D8AD420E8");

            entity.ToTable("Reservation");

            entity.Property(e => e.Idreservation).HasColumnName("IDReservation");
            entity.Property(e => e.DateReservation).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Employee).WithMany(p => p.ReservationEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Reservati__Emplo__440B1D61");

            entity.HasOne(d => d.Guest).WithMany(p => p.ReservationGuests)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK__Reservati__Guest__4316F928");

            entity.HasOne(d => d.Order).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Reservati__Order__4222D4EF");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__412EB0B6");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Idtable).HasName("PK__Table__72B3DFF479C456A5");

            entity.ToTable("Table");

            entity.Property(e => e.Idtable).HasColumnName("IDTable");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Idtransaction).HasName("PK__Transact__A3F081DF4375348E");

            entity.ToTable("Transaction");

            entity.Property(e => e.Idtransaction).HasColumnName("IDTransaction");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Transacti__Order__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__46E78A0C");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.IduserType).HasName("PK__UserType__EA4074F28C4EE3A2");

            entity.ToTable("UserType");

            entity.Property(e => e.IduserType).HasColumnName("IDUserType");
            entity.Property(e => e.UserTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
           
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DF0CC32A27");

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
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

            //entity.HasOne(d => d.UserType).WithMany(p => p.Users)
            //    .HasForeignKey(d => d.UserTypeId)
            //    .HasConstraintName("FK__User__UserTypeID__398D8EEE");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
