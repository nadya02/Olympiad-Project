using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Sports
    {
        public Sports()
        {
            Competitors = new HashSet<Competitors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competitors> Competitors { get; set; }
    }
}
