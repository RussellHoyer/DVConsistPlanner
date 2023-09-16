using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using System.Linq;

namespace DVConsistPlanner.Pages
{
    public class ConsistListModel : PageModel
    {
        private readonly ILogger<ConsistListModel> _logger;
        IConsistManager _consistManager;

        public ConsistListModel(ILogger<ConsistListModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
        }

        [BindProperty]
        public List<Consist> Consists { get; set; }

        public void OnGet()
        {
            Consists = _consistManager.GetConsists().ToList();
        }
    }
}
