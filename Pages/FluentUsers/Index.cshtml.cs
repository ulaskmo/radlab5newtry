using Microsoft.AspNetCore.Mvc.RazorPages;
using radlab5._1.Data;
using radlab5._1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace radlab5._1.Pages.FluentUsers
{
    public class IndexModel : PageModel
    {
        private readonly FluentUserDbContext _context;

        public IndexModel(FluentUserDbContext context)
        {
            _context = context;
        }

        public IList<FluentUser> FluentUsers { get; set; }

        public async Task OnGetAsync()
        {
            FluentUsers = await _context.FluentUsers.ToListAsync() ?? new List<FluentUser>();
        }
    }
}