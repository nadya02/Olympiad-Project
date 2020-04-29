using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Competitors = new HashSet<Competitors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Competitors> Competitors { get; set; }
    }
}
