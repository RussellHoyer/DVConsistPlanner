using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace DVConsistPlanner.Pages.Locomotives
{
    public class EditLocomotiveModel : PageModel
    {
        private readonly ILogger<EditLocomotiveModel> _logger;
        private readonly IConsistManager _consistManager;

        public EditLocomotiveModel(ILogger<EditLocomotiveModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
        }

        [BindProperty]
        public Locomotive Loco { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _consistManager.ActiveConsist == null)
            {
                return NotFound();
            }

            Loco = _consistManager.GetLocomotive((int)id);
            if (Loco == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid ||  Loco == null)
            {
                return Page();
            }

            _consistManager.UpdateLocomotive(Loco);
            return RedirectToPage("../ConsistManager", new { id = Loco.ConsistID });
        }
    }
}
