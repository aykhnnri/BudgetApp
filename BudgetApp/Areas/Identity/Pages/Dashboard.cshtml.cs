using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using BudgetApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp.Areas.Identity.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<BudgetAppUser> _userManager;

        public DashboardModel(DBContext context, UserManager<BudgetAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public decimal Balance { get; set; }
        public List<Transaction> RecentTransactions { get; set; }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            Balance = await _context.UserBudgets
                           .Where(ub => ub.Id == user.Id)
                           .SumAsync(ub => ub.budget_amount);

            RecentTransactions = await _context.Transactions
                                               .Where(t => t.Id == user.Id)
                                               .OrderByDescending(t => t.date)
                                               .Take(5)
                                               .ToListAsync();

            return Page();
        }
    }


}
