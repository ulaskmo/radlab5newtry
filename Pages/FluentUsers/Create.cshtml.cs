using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using radlab5._1.Data;
using radlab5._1.Models;

namespace radlab5._1.Pages.FluentUsers
{
    public class CreateModel : PageModel
    {
        private readonly radlab5._1.Data.FluentUserDbContext _context;

        public CreateModel(radlab5._1.Data.FluentUserDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FluentUsers.Add(FluentUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
