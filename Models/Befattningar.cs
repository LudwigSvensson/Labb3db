using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Befattningar
    {
        public Befattningar()
        {
            Anställda = new HashSet<Anställdum>();
        }

        public int BefattningsId { get; set; }
        public string? Befattninsnamn { get; set; }

        public virtual ICollection<Anställdum> Anställda { get; set; }
    }
}
