using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Clubs
    {
        public Clubs()
        {
            Competitors = new HashSet<Competitors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competitors> Competitors { get; set; }
    }
}
