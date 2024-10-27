using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using radlab5._1.Data;
using radlab5._1.Models;

namespace radlab5._1.Pages.FluentUsers
{
    public class EditModel : PageModel
    {
        private readonly radlab5._1.Data.FluentUserDbContext _context;

        public EditModel(radlab5._1.Data.FluentUserDbContext context)
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

            var fluentuser =  await _context.FluentUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (fluentuser == null)
            {
                return NotFound();
            }
            FluentUser = fluentuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FluentUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FluentUserExists(FluentUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FluentUserExists(int id)
        {
            return _context.FluentUsers.Any(e => e.Id == id);
        }
    }
}
