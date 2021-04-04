using BowlingAssignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAssignment10.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        //This is where the navbar for the teams are built
        public NavigationMenuViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            var NavBarList = context.Bowlers

                //These are similar to SQL commands and makes it so that each team is selected,
                //That only 1 distinct instance of each is used, and how they are ordered 
                .Select(b => b.Team)
                .Distinct()
                .OrderBy(b => b);


            return View(NavBarList);
        }
    }
}
