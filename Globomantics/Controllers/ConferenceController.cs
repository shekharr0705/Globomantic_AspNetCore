using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Controllers
{
    public class ConferenceController:Controller
    {
        private IConferenceService _conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conference Overview";
            return View(await _conferenceService.GetAll());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel conference)
        {
            if (ModelState.IsValid)
                await _conferenceService.Add(conference);
            return RedirectToAction(nameof(Index));
        }
    }
}
