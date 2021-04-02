using System;
using System.Collections.Generic;

namespace BowlingAssignment10.Models
{
    public partial class Bowlers
    {
        public Bowlers()
        {
            BowlerScores = new HashSet<BowlerScores>();
        }

        public long BowlerId { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public int BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        public long? TeamId { get; set; }

        public virtual Teams Team { get; set; }
        public virtual ICollection<BowlerScores> BowlerScores { get; set; }
    }
}
