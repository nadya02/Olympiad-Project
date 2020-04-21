using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Competitors
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int TownId { get; set; }
        public int SportId { get; set; }
        public int CoachId { get; set; }

        public virtual Coaches Coach { get; set; }
        public virtual Sports Sport { get; set; }
        public virtual Towns Town { get; set; }
    }
}
