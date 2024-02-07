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

        public static void KlassInfo(Labb3dbContext context)
        {
            Console.WriteLine("Välj en klass du vill se info om:");

            var klassNamn = context.Klassers
                .OrderBy(k => k.Klassnamn)
                .Select(k => k.Klassnamn)
                .ToList();

            for (int i = 0; i < klassNamn.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {klassNamn[i]}");
            }

            var val2 = Console.ReadLine();

            if (int.TryParse(val2, out int klassIndex) && klassIndex >= 1 && klassIndex <= klassNamn.Count)
            {

                var valdKlass = context.Klassers
                    .OrderBy(k => k.Klassnamn)
                    .Skip(klassIndex - 1)
                    .FirstOrDefault();

                if (valdKlass != null)
                {
                    Console.WriteLine($"Classname: {valdKlass.Klassnamn}");
                    Console.WriteLine(new string('-', 30));
                    var eleverIKlass = context.Elevers
                        .Where(e => e.KlassId == valdKlass.KlassId)
                        .OrderBy(e => e.Förnamn)
                        .ToList();
                    foreach (Elever e in eleverIKlass)
                    {
                        Console.WriteLine($"Name: {e.Förnamn} {e.Efternamn}");
                        Console.WriteLine(new string('-', 30));
                    }
                    Console.WriteLine("Tryck Enter för att åtregå till meny");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("Då måste välja en av de klasser i listan");
                }
            }
            else
            {
                Console.WriteLine("FEL. Du MÅSTE välja en av de klasser i listan");
            }
        }
    }


}
