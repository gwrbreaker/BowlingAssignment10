using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAssignment10.Models.ViewModels
{
    public class BowlingTeamViewModel
    {
        //These are the view models for the database of bowlers enumeration, and the information for getting and setting 
        //the paging info
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string TeamName { get; set; }
    }
}
