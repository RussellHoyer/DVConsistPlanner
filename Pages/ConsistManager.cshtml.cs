using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVConsistPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using static DVConsistPlanner.Models.DerailValley;

namespace DVConsistPlanner.Pages
{
    public class ConsistManagerModel : PageModel
    {
        private readonly ILogger<ConsistManagerModel> _logger;
        public Consist Consist;
        private readonly TestModel _testModel;

        public ConsistManagerModel(ILogger<ConsistManagerModel> logger)
        {
            _logger = logger;
            _testModel = new TestModel();
        }

        public void OnGet()
        {
            Consist = _testModel.GetTestConsist();
        }
    }
}
