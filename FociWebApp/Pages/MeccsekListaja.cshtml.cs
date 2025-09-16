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
    public class MeccsekListajaModel : PageModel
    {
        private readonly FociWebApp.Data.FociDbContext _context;

        public MeccsekListajaModel(FociWebApp.Data.FociDbContext context)
        {
            _context = context;
        }

        public IList<Meccs> Meccs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.meccsek.ToListAsync();
        }
    }
}
