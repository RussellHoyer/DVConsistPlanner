using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVConsistPlanner.Pages
{
    public class AddJobModel : PageModel
    {
        private readonly ILogger<ConsistManagerModel> _logger;
        IConsistManager _consistManager;

        public AddJobModel(ILogger<ConsistManagerModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
            Job = new Job();
        }

        [BindProperty]
        public Job Job { get; set; }
        [BindProperty]
        public string DepartingStationAbbrev { get; set; }
        [BindProperty]
        public string ArrivingStationAbbrev { get; set; }

        public List<SelectListItem> StationList { get; set; }
        public List<SelectListItem> JobTypeList { get; set; }

        public void OnGet()
        {
            StationList = DerailValleyData.Stations.GetStationList().Select(
                s => new SelectListItem
                {
                    Value = s.Abbreviation,
                    Text = s.Name
                }).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Job == null)
            {
                return Page();
            }

            Job.Departing = DerailValleyData.Stations.GetStationByAbbrev(DepartingStationAbbrev);
            Job.Arriving = DerailValleyData.Stations.GetStationByAbbrev(ArrivingStationAbbrev);

            _consistManager.AddJob(Job);

            return RedirectToPage("./ConsistManager");

        }
    }
}