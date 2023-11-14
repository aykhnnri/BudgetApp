using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using BudgetApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Areas.Identity.Pages
{
    public class AddTransactionModel : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<BudgetAppUser> _userManager;

        public AddTransactionModel(DBContext context, UserManager<BudgetAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Returns the page with validation errors.
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Transaction.Id = user.Id; // Ensure the UserId is set.

            _context.Transactions.Add(Transaction); // Adds the transaction to the context.
            await _context.SaveChangesAsync(); // Saves changes to the database.

            return RedirectToPage("./Transactions"); // Redirects to the Transactions page.
        }
    }

}
