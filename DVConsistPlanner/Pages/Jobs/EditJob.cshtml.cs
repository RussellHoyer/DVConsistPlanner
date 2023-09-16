using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVConsistPlanner.Pages.Jobs
{
    public class EditJobModel : PageModel
    {
        private readonly ILogger<EditJobModel> _logger;
        IConsistManager _consistManager;

        public EditJobModel(ILogger<EditJobModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
        }

        [BindProperty]
        public Job Job { get; set; }
        [BindProperty]
        public string DepartingStationAbbrev { get; set; }
        [BindProperty]
        public string ArrivingStationAbbrev { get; set; }

        public List<SelectListItem> StationList { get; set; }
        public List<SelectListItem> JobTypeList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _consistManager.ActiveConsist == null)
            {
                return NotFound();
            }
            StationList = DerailValleyData.Stations.GetStationList().Select(
                s => new SelectListItem
                {
                    Value = s.Abbreviation,
                    Text = s.Name
                }).ToList();

            var editingJob = _consistManager.GetJob((int)id);
            if (editingJob == null)
            {
                return NotFound();
            }
            Job = editingJob;

            DepartingStationAbbrev = Job.Departing.Abbreviation;
            ArrivingStationAbbrev = Job.Arriving.Abbreviation;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Job == null)
            {
                return Page();
            }

            Job.Departing = DerailValleyData.Stations.GetStationByAbbrev(DepartingStationAbbrev);
            Job.Arriving = DerailValleyData.Stations.GetStationByAbbrev(ArrivingStationAbbrev);

            _consistManager.UpdateJob(Job);
            return RedirectToPage("../ConsistManager", new { id = Job.ConsistID });
        }
    }
}
