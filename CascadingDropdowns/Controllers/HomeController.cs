using CascadingDropdowns.Data;
using CascadingDropdowns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CascadingDropdowns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext Context { get; }

        public HomeController(ILogger<HomeController> logger, AppDbContext _context)
        {
            _logger = logger;
            Context = _context;
        }

        public IActionResult Index()
        {
            //get country list as SelectListItem
            ViewBag.Country = Context.Country.ToList().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            return View();
        }

        //this method is called using jQuery
        public IActionResult GetStates(int id)
        {
            //get state list as SelectListItem
            var statesList = Context.State.Where(s => s.CountryID == id).ToList().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.StateName }).ToList();
            return Json(statesList);
        }
        //method where form is posted
        [HttpPost]
        public IActionResult Index(int Country, int State)
        {
            //get selected country/state name
            ViewBag.SelectedCountry = Context.Country.Where(a => a.Id == Country).FirstOrDefault().CountryName;
            ViewBag.SelectedState = Context.State.Where(a => a.Id == State).FirstOrDefault().StateName;

            //again get country list as SelectListItem 
            ViewBag.Country = Context.Country.ToList().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CountryName }).ToList();
            return View();
        }
    }
}