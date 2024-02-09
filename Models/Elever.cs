using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Labb3db.Models
{
    public partial class Kruser
    {
        public Kruser()
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
            Console.Clear();
            Console.WriteLine("Välj [1] för att sortera ALLA i bokstavsordning med förnamn" +
                                    "\nVälj [2] för att sortera ALLA i bokstavsordning med efternamn" +
                                    "\nVälj [3] för att sortera ALLA efter ElevID");
            var ordningsval = Console.ReadLine();
            switch (ordningsval)
            {
                case "1":
                    var elever = context.Elevers
                    .OrderBy(e => e.Förnamn)
                    .Join(context.Klassers,
                    elev => elev.KlassId,
                    klass => klass.KlassId,
                    (elev, klass) => new { Elev = elev, Klassnamn = klass.Klassnamn }); 

                    foreach (var item in elever)
                    {
                        Console.WriteLine($"ElevID: {item.Elev.ElevId} \nName: {item.Elev.Förnamn} {item.Elev.Efternamn} \nKlass: {item.Klassnamn} \nPersonnummer: {item.Elev.Personnummer}");
                        Console.WriteLine(new string('-', 30));
                    }
                    break;
                case "2":
                    elever = context.Elevers
                    .OrderBy(e => e.Efternamn)
                    .Join(context.Klassers,
                    elev => elev.KlassId,
                    klass => klass.KlassId,
                    (elev, klass) => new { Elev = elev, Klassnamn = klass.Klassnamn });

                    foreach (var item in elever)
                    {
                        Console.WriteLine($"ElevID: {item.Elev.ElevId} \nName: {item.Elev.Förnamn} {item.Elev.Efternamn} \nKlass: {item.Klassnamn} \nPersonnummer: {item.Elev.Personnummer}");
                        Console.WriteLine(new string('-', 30));
                    }
                    Console.WriteLine("Tryck Enter för att åtregå till meny");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    elever = context.Elevers
                    .Join(context.Klassers,
                    elev => elev.KlassId,
                    klass => klass.KlassId,
                    (elev, klass) => new { Elev = elev, Klassnamn = klass.Klassnamn });

                    foreach (var item in elever)
                    {
                        Console.WriteLine($"ElevID: {item.Elev.ElevId} \nName: {item.Elev.Förnamn} {item.Elev.Efternamn} \nKlass: {item.Klassnamn} \nPersonnummer: {item.Elev.Personnummer}");
                        Console.WriteLine(new string('-', 30));
                    }                    
                    break;
                default:
                    Console.WriteLine("FEL.");
                    break;
            }
            Console.WriteLine("Tryck Enter för att återgå till meny");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
