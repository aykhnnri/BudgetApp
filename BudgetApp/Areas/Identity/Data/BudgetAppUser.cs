using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BudgetAppUser class
public class BudgetAppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Email { get; set; }
    public string PhoneNum { get; set; }
    public string PostalCode { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<UserBudget> UserBudgets { get; set; }
    public ICollection<SavedSearch> SavedSearches { get; set; }
    public ICollection<LinkedAccount> LinkedAccounts { get; set; }
    public Settings Settings { get; set; }
}

public class Transaction
{
    [Key]
    public int transaction_id { get; set; }
    [ForeignKey("BudgetAppUser")]
    public string Id { get; set; }
    public int category_id { get; set; }
    public decimal amount { get; set; }
    public string description { get; set; }
    public DateTime date { get; set; }

    // Navigation properties
    public BudgetAppUser User { get; set; }
    public BudgetCategory BudgetCategory { get; set; }
}

public class UserBudget
{
    [ForeignKey("BudgetAppUser")]
    public string Id { get; set; }

    public int category_id { get; set; }
    public decimal budget_amount { get; set; }

    public BudgetAppUser User { get; set; }
    public BudgetCategory BudgetCategory { get; set; }
}

public class BudgetCategory

{
    [Key]
    public int category_id { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<UserBudget> UserBudgets { get; set; }
    public ICollection<SavedSearch> SavedSearches { get; set; }
}

public class Settings
{
    [ForeignKey("BudgetAppUser")]
    public string Id { get; set; }
    public int logout_timer { get; set; }
    public string authenticator { get; set; }

    // Navigation property
    public BudgetAppUser User { get; set; }
}

public class SavedSearch
{
    [Key]
    public int search_id { get; set; }
    [ForeignKey("BudgetAppUser")]
    public string Id { get; set; }
    public int category_id { get; set; }
    public string search_parameters { get; set; }

    // Navigation properties
    public BudgetAppUser User { get; set; }
    public BudgetCategory BudgetCategory { get; set; }
}

public class LinkedAccount
{
    [Key]
    public int account_id { get; set; }
    [ForeignKey("BudgetAppUser")]
    public string Id { get; set; }
    public string account_type { get; set; }
    public string account_number { get; set; }

    // Navigation property
    public BudgetAppUser User { get; set; }
}