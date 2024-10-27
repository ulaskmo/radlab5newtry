using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using radlab5._1.Data;
using radlab5._1.Models;

namespace radlab5._1.Pages.FluentUsers
{
    public class DeleteModel : PageModel
    {
        private readonly radlab5._1.Data.FluentUserDbContext _context;

        public DeleteModel(radlab5._1.Data.FluentUserDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FluentUser FluentUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.FluentUsers.FirstOrDefaultAsync(m => m.Id == id);

            if (fluentuser == null)
            {
                return NotFound();
            }
            else
            {
                FluentUser = fluentuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentuser = await _context.FluentUsers.FindAsync(id);
            if (fluentuser != null)
            {
                FluentUser = fluentuser;
                _context.FluentUsers.Remove(FluentUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
