using FociWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebApp.Pages
{
    public class CsapatokListajaModel : PageModel
    {
        private readonly FociDbContext _context;
        public CsapatokListajaModel(FociDbContext context)
        {
            _context = context;
        }

        public IList<string> Csapatok { get; set; } = default!;

        [BindProperty]
        public int MyProperty { get; set; }

        public void OnGet()
        {
            Csapatok = _context.meccsek.Select(x => x.HazaiCsapat)
                .Distinct()
                .ToList();
        }
    }
}
