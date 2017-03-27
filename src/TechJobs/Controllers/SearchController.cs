using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        //takes in two parameters, 'type of search' and 'search term'

        // [Route("/Search/Index")]
        // [HttpPost]
        // public IActionResult Search(string searchType, string searchTerm)
        // {
            /* Fetch results
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.jobs = jobs;
                ViewBag.columns = ListController.columnChoices;
                return View();
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.columns = ListController.columnChoices;
                return View();
            }*/

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
            }

            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search By ";
            return View("Index");
        }

    }
}
