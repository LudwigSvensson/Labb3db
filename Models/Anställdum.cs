using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Anställdum
    {
        public Anställdum()
        {
            Betygs = new HashSet<Betyg>();
            Klasses = new HashSet<Klasser>();
            Kurs = new HashSet<Kurser>();
        }

        public int AnställningsId { get; set; }
        public int? BefattningsId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }

        public virtual Befattningar? Befattnings { get; set; }
        public virtual ICollection<Betyg> Betygs { get; set; }

        public virtual ICollection<Klasser> Klasses { get; set; }
        public virtual ICollection<Kurser> Kurs { get; set; }
    }
}
