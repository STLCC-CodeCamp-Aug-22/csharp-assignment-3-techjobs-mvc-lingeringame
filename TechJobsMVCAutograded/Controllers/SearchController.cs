using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded.Data;
using TechJobsMVCAutograded.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVCAutograded.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View(ViewBag.jobs);
        }

        // TODO #3 - Create an action method to process a search request and render the updated search views.
        public IActionResult Results(string searchType, string searchTerm)
        {
            //List<Job> jobs;
            ViewBag.jobs = null;
            if(searchTerm.ToLower() == "all" || string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.jobs = new List<Job>(JobData.FindAll());
            } else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            return View(ListController.ColumnChoices);
        }
    }
}
