using DVConsistPlanner.Models;
using DVConsistPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DVConsistPlanner.Pages.Locomotives
{
    public class AddLocomotiveModel : PageModel
    {
        private readonly ILogger<AddLocomotiveModel> _logger;
        IConsistManager _consistManager;

        public AddLocomotiveModel(ILogger<AddLocomotiveModel> logger, IConsistManager consistManager)
        {
            _logger = logger;
            _consistManager = consistManager;
            Loco = _consistManager.GetNewLocomotive();
        }
        public List<Locomotive> Locomotives { get; set; }

        [BindProperty]
        public Locomotive Loco { get; set; }
        [BindProperty]
        public string SelectedLoco { get; set; }

        public List<SelectListItem> LocoSelectList { get; set; }

        public void OnGet()
        {
            Locomotives = DerailValleyData.Locomotives.GetLocomotivesList();
            LocoSelectList = Locomotives.Select(
                l => new SelectListItem
                {
                    Value = l.Classification,
                    Text = l.Classification
                }).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Loco == null || string.IsNullOrEmpty(SelectedLoco))
            {
                return Page();
            }

            Loco.CopyFrom(DerailValleyData.Locomotives.GetLocomotiveByClass(SelectedLoco));
            Loco.ConsistID = _consistManager.ActiveConsist.ID;
            _consistManager.AddLocomotive(Loco);

            return RedirectToPage("./ConsistManager");

        }
    }
}
