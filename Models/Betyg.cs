using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Betyg
    {
        public int BetygsId { get; set; }
        public int? ElevId { get; set; }
        public int? AnställningsId { get; set; }
        public int? KursId { get; set; }
        public string? Betyg1 { get; set; }
        public DateTime? DatumSatt { get; set; }

        public virtual Anställdum? Anställnings { get; set; }
        public virtual Elever? Elev { get; set; }
        public virtual Kurser? Kurs { get; set; }
    }
}
