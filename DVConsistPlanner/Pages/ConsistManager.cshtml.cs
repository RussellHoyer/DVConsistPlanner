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
        DVCPContext _context;

        public ConsistManagerModel(ILogger<ConsistManagerModel> logger, IConsistManager consistManager, DVCPContext dVCPContext)
        {
            _logger = logger;
            _consistManager = consistManager;
            _context = dVCPContext;
        }

        public void OnGet()
        {
            Consist = _consistManager.GetConsists().FirstOrDefault();
        }
    }
}
