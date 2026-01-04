using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVConsistPlanner.Contexts;
using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DVConsistPlanner.Pages
{
    public class ConsistManagerModel : PageModel
    {
        private readonly ILogger<ConsistManagerModel> _logger;

        public Consist Consist;
        IConsistManager _consistManager;

        public ConsistManagerModel(ILogger<ConsistManagerModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //Consist = _consistManager.ActiveConsist;
            if (id == null) return BadRequest();
            Consist = _consistManager.GetConsist((int)id);
            if (Consist == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnGetClearConsist()
        {
            Consist = _consistManager.ActiveConsist;
            _consistManager.ResetConsist();

            return Page();
        }

        public IActionResult OnGetDeleteLocomotive(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var locomotive = _consistManager.GetLocomotive((int)id);
            if (locomotive == null)
            {
                return NotFound();
            }

            var consistId = locomotive.ConsistID;
            _consistManager.RemoveLocomotive((int)id);

            return RedirectToPage(new { id = consistId });
        }

        public IActionResult OnGetDeleteJob(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var job = _consistManager.GetJob((int)id);
            if (job == null)
            {
                return NotFound();
            }

            var consistId = job.ConsistID;
            _consistManager.RemoveJob((int)id);

            return RedirectToPage(new { id = consistId });
        }

        public string GetAlertClassLoadRating()
        {
            if (Consist.TotalTonnage > Consist.Locomotives.GetTotalLoadRating())
            {
                return "alarm_color_red";
            }
            return "alarm_color_black";
        }
    }
}
