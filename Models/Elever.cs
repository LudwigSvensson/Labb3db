using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Elever
    {
        public Elever()
        {
            Betygs = new HashSet<Betyg>();
        }

        public int ElevId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public DateTime? Personnummer { get; set; }
        public int? KlassId { get; set; }

        public virtual Klasser? Klass { get; set; }
        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
