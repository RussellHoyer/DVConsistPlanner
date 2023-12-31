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
