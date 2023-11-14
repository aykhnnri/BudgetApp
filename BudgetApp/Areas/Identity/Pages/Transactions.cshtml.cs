using BudgetApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace BudgetApp.Areas.Identity.Pages
{
    public class TransactionsModel : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<BudgetAppUser> _userManager;

        public TransactionsModel(DBContext context, UserManager<BudgetAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Transaction> AllTransactions { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            AllTransactions = await _context.Transactions
                                            .Where(t => t.Id == user.Id)
                                            .OrderByDescending(t => t.date)
                                            .ToListAsync();

            return Page();
        }
    }


}
