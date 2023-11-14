using BudgetApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BudgetApp.Areas.Identity.Data;

public class DBContext : IdentityDbContext<BudgetAppUser>
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options) {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<UserBudget> UserBudgets { get; set; }
    public DbSet<BudgetCategory> BudgetCategories { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<SavedSearch> SavedSearches { get; set; }
    public DbSet<LinkedAccount> LinkedAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        builder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.transaction_id);
            entity.HasOne(e => e.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(e => e.Id);
            entity.HasOne(e => e.BudgetCategory)
                .WithMany(c => c.Transactions)
                .HasForeignKey(e => e.category_id);
        });

        builder.Entity<UserBudget>(entity =>
        {
            entity.HasKey(ub => new { ub.Id, ub.category_id });
            entity.HasOne(ub => ub.User)
                .WithMany(u => u.UserBudgets)
                .HasForeignKey(ub => ub.Id);
            entity.HasOne(ub => ub.BudgetCategory)
                .WithMany(c => c.UserBudgets)
                .HasForeignKey(ub => ub.category_id);
        });

        builder.Entity<BudgetCategory>()
            .HasKey(bc => bc.category_id);

        builder.Entity<Settings>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.HasOne(s => s.User)
                .WithOne(u => u.Settings)
                .HasForeignKey<Settings>(s => s.Id);
        });

        builder.Entity<SavedSearch>(entity =>
        {
            entity.HasKey(ss => ss.search_id);
            entity.HasOne(ss => ss.User)
                .WithMany(u => u.SavedSearches)
                .HasForeignKey(ss => ss.Id);
            entity.HasOne(ss => ss.BudgetCategory)
                .WithMany(bc => bc.SavedSearches)
                .HasForeignKey(ss => ss.category_id);
        });

        builder.Entity<LinkedAccount>(entity =>
        {
            entity.HasKey(la => la.account_id);
            entity.HasOne(la => la.User)
                .WithMany(u => u.LinkedAccounts)
                .HasForeignKey(la => la.Id);
        });
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<BudgetAppUser>
{
    public void Configure(EntityTypeBuilder<BudgetAppUser> builder)
    {
        builder.Property(x => x.Id).HasMaxLength(450);
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.MiddleName).HasMaxLength(100);
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.PostalCode).HasMaxLength(100);
        builder.Property(x => x.PhoneNum).HasMaxLength(100);
    }
}