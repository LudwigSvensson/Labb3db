using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Klasser
    {
        public Klasser()
        {
            Elevers = new HashSet<Elever>();
            Lärares = new HashSet<Anställdum>();
        }

        public int KlassId { get; set; }
        public string Klassnamn { get; set; } = null!;

        public virtual ICollection<Elever> Elevers { get; set; }

        public virtual ICollection<Anställdum> Lärares { get; set; }
    }
}
