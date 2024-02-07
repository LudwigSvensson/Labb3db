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

        public static void ElevInfo(Labb3dbContext context)
        {
            Console.WriteLine("Välj [1] för att sortera ALLA i bokstavsordning med förnamn" +
                                    "\nVälj [2] för att sortera ALLA i bokstavsordning med efternamn");
            var ordningsval = Console.ReadLine();
            switch (ordningsval)
            {
                case "1":
                    var elever = context.Elevers
                    .OrderBy(e => e.Förnamn);
                    foreach (Elever e in elever)
                    {
                        Console.WriteLine($"Name: {e.Förnamn} {e.Efternamn}");
                        Console.WriteLine(new string('-', 30));
                    }
                    break;
                case "2":
                    elever = context.Elevers
                    .OrderBy(e => e.Efternamn);
                    foreach (Elever e in elever)
                    {
                        Console.WriteLine($"Name: {e.Förnamn} {e.Efternamn}");
                        Console.WriteLine(new string('-', 30));
                    }                    
                    Console.WriteLine("Tryck Enter för att åtregå till meny");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                default:
                    Console.WriteLine("FEL.");
                    break;
            }
        }
    }
}
