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

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductTime> ProductTimes { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:RestorankoConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Idguest).HasName("PK__Guest__045D2BC2F289F149");

            entity.ToTable("Guest");

            entity.Property(e => e.Idguest).HasColumnName("IDGuest");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Guests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Guest__UserID__7E37BEF6");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__BEAEB27A8A4ADB07");

            entity.ToTable("Ingredient");

            entity.Property(e => e.IngredientId)
                .ValueGeneratedNever()
                .HasColumnName("IngredientID");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Idinventory).HasName("PK__Inventor__CD45C7BE58077799");

            entity.ToTable("Inventory");

            entity.Property(e => e.Idinventory).HasColumnName("IDInventory");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__Produ__123EB7A3");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iditem).HasName("PK__Item__C9778A1005990E06");

            entity.ToTable("Item");

            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Job).WithMany(p => p.Items)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Item__JobID__0D7A0286");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Item__OrderID__0F624AF8");

            entity.HasOne(d => d.Product).WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Item__ProductID__0E6E26BF");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Idjob).HasName("PK__Job__9553E224AAC45F8F");

            entity.ToTable("Job");

            entity.Property(e => e.Idjob).HasColumnName("IDJob");
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK__Job__JobTypeID__7B5B524B");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Job__UserID__7A672E12");

            entity.HasMany(d => d.JobTypes).WithMany(p => p.JobsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "JobJobType",
                    r => r.HasOne<JobType>().WithMany()
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Job_JobTy__JobTy__25518C17"),
                    l => l.HasOne<Job>().WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Job_JobTy__JobID__245D67DE"),
                    j =>
                    {
                        j.HasKey("JobId", "JobTypeId").HasName("PK__Job_JobT__CB79D6C639616AE9");
                        j.ToTable("Job_JobType");
                        j.IndexerProperty<int>("JobId").HasColumnName("JobID");
                        j.IndexerProperty<int>("JobTypeId").HasColumnName("JobTypeID");
                    });
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.IdjobType).HasName("PK__JobType__40FBA956D88546F2");

            entity.ToTable("JobType");

            entity.Property(e => e.IdjobType).HasColumnName("IDJobType");
            entity.Property(e => e.JobTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorder).HasName("PK__Order__5CBBCADB2D0E0CBD");

            entity.ToTable("Order");

            entity.Property(e => e.Idorder).HasColumnName("IDOrder");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.WaiterId).HasColumnName("WaiterID");

            entity.HasOne(d => d.Waiter).WithMany(p => p.Orders)
                .HasForeignKey(d => d.WaiterId)
                .HasConstraintName("FK__Order__WaiterID__02FC7413");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idproduct).HasName("PK__Product__4290D179F6E480D4");

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
                        .HasConstraintName("FK__Product_O__Order__2CF2ADDF"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Product_O__Produ__2BFE89A6"),
                    j =>
                    {
                        j.HasKey("ProductId", "OrderId").HasName("PK__Product___5835C35789B3F47C");
                        j.ToTable("Product_Order");
                        j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        j.IndexerProperty<int>("OrderId").HasColumnName("OrderID");
                    });
        });

        modelBuilder.Entity<ProductTime>(entity =>
        {
            entity.HasKey(e => e.IdproductTime).HasName("PK__ProductT__2719F40C52B433CA");

            entity.ToTable("ProductTime");

            entity.Property(e => e.IdproductTime).HasColumnName("IDProductTime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductTimes)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTime_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTimes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTime_Product");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipe__FDD988D0B4B0D689");

            entity.ToTable("Recipe");

            entity.Property(e => e.RecipeId)
                .ValueGeneratedNever()
                .HasColumnName("RecipeID");
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
            entity.HasKey(e => new { e.RecipeId, e.IngredientId }).HasName("PK__RecipeIn__463363F76242D65C");

            entity.ToTable("RecipeIngredient");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeIng__Ingre__19DFD96B");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeIng__Recip__18EBB532");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Idreservation).HasName("PK__Reservat__53DF2D8D146E01E7");

            entity.ToTable("Reservation");

            entity.Property(e => e.Idreservation).HasColumnName("IDReservation");
            entity.Property(e => e.DateReservation).HasColumnType("datetime");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK__Reservati__Guest__07C12930");

            entity.HasOne(d => d.Order).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Reservati__Order__06CD04F7");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__05D8E0BE");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reservati__UserI__08B54D69");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Idtable).HasName("PK__Table__72B3DFF4146AE017");

            entity.ToTable("Table");

            entity.Property(e => e.Idtable).HasColumnName("IDTable");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Idtransaction).HasName("PK__Transact__A3F081DFF104BAE6");

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
                .HasConstraintName("FK__Transacti__Order__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__208CD6FA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__User__EAE6D9DFC100AFED");

            entity.ToTable("User");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false).HasColumnName("Email");
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
                        .HasConstraintName("FK__User_Gues__Guest__29221CFB"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Gues__UserI__282DF8C2"),
                    j =>
                    {
                        j.HasKey("UserId", "GuestId").HasName("PK__User_Gue__274CEF6F04855A55");
                        j.ToTable("User_Guest");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("GuestId").HasColumnName("GuestID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
