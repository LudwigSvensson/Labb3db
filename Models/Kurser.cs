using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Kurser
    {
        public Kurser()
        {
            Betygs = new HashSet<Betyg>();
            Lärares = new HashSet<Anställdum>();
        }
        public int KursId { get; set; }
        public string Kurstitel { get; set; } = null!;

        public virtual ICollection<Betyg> Betygs { get; set; }

        public virtual ICollection<Anställdum> Lärares { get; set; }
        public static void KursInfo(Labb3dbContext context)
        {
            Console.Clear();

                    var kurser = context.Kursers
                    .OrderBy(k => k.Kurstitel);
                    foreach (Kurser k in kurser)
                    {
                        Console.WriteLine($"{k.Kurstitel}");
                        Console.WriteLine(new string('-', 30));
                    }    
        }
    }
}
