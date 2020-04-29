using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Towns = new HashSet<Towns>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Towns> Towns { get; set; }
    }
}
