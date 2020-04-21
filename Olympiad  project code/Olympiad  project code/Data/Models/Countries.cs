using System;
using System.Collections.Generic;

namespace Olympiad__project_code.Models
{
    public partial class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Towns Towns { get; set; }
    }
}
