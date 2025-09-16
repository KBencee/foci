using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FociWebApp.Data;
using FociWebApp.Models;

namespace FociWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly FociWebApp.Data.FociDbContext _context;

        public DeleteModel(FociWebApp.Data.FociDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meccs Meccs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meccs = await _context.meccsek.FirstOrDefaultAsync(m => m.Id == id);

            if (meccs == null)
            {
                return NotFound();
            }
            else
            {
                Meccs = meccs;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meccs = await _context.meccsek.FindAsync(id);
            if (meccs != null)
            {
                Meccs = meccs;
                _context.meccsek.Remove(Meccs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
