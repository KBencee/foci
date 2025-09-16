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
    public class CsapatEredmenyeiModel : PageModel
    {
        private readonly FociWebApp.Data.FociDbContext _context;

        public CsapatEredmenyeiModel(FociWebApp.Data.FociDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string KivalasztottCsapat { get; set; } = default!;

        public IList<string> Csapatok { get;set; } = default!;
        public IList<Meccs> Meccs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Csapatok = await _context.meccsek
                .Select(x => x.HazaiCsapat)
                .Union(_context.meccsek.Select(x => x.VendegCsapat))
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            Meccs = await _context.meccsek.
                Where(x => x.HazaiCsapat == KivalasztottCsapat || x.VendegCsapat == KivalasztottCsapat).
                ToListAsync();
        }
    }
}
