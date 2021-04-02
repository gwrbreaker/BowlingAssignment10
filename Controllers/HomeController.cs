using BowlingAssignment10.Models;
using BowlingAssignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAssignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(int page = 1)
        {
            return View(new BowlingTeamViewModel
            {
                //This is where the function of the team name buttons are built, 
                //making it so that the team name button of each type selects all the same
                //players of that team
                Bowlers = context.Bowlers
                .OrderBy(x => x.BowlerFirstName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)

                ,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = context.Bowlers.Count()
                }
            });
        }

        public IActionResult GetTeam(string teamname)
        {

            ViewBag.TeamName = teamname;

            return View("Index", new BowlingTeamViewModel
            {
                Bowlers = context.Bowlers
                .Where(x => x.Team.TeamName == teamname)

                ,

                PagingInfo = new PagingInfo
                {
                    //This is where the number of pages returned is calculated when filtered for 
                    //a specific team
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalNumItems = context.Bowlers.Where(x => x.Team.TeamName == teamname).Count()
                }
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
