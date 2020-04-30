using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Coaches
    {
        public Coaches()
        {
            Competitors = new HashSet<Competitors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }

        public virtual Sports Sport { get; set; }
        public virtual ICollection<Competitors> Competitors { get; set; }
    }
}
