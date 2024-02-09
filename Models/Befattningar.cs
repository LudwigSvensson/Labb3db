using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb3db.Models
{
    public partial class Befattningar
    {
        public Befattningar()
        {
            Anställda = new HashSet<Anställdum>();
        }
        [Key]
        public int BefattningsId { get; set; }
        public string? Befattninsnamn { get; set; }

        public virtual ICollection<Anställdum> Anställda { get; set; }

        public static void AnställdaPerBefattning(Labb3dbContext context)
        {
            Console.Clear();

            // Hämta antalet anställda per BefattningsId
            var anställdaPerBefattningsId = context.Anställda
                .GroupBy(a => a.Befattnings.Befattninsnamn)
                .Select(a => new
                {
                    Befattningsnamn = a.Key,
                    AntalAnställda = a.Count()
                });

            // Skriv ut resultaten
            Console.WriteLine("Total antal anställda på skolan:");
            foreach (var anställdaGrupp in anställdaPerBefattningsId)
            {
                Console.WriteLine($"{anställdaGrupp.Befattningsnamn}: {anställdaGrupp.AntalAnställda} anställda");

            }
            Console.WriteLine("\nVälj [1], [2], [3] eller [4] för att skriva ut namn på de anställda" +
                "\n[1]Lärare" +
                "\n[2]Receptionist" +
                "\n[3]Rektor" +
                "\n[4]Vaktmästare");
            
            InfoOmYrken(context);
        }

        public static void InfoOmYrken(Labb3dbContext context)
        {
            bool go = true;
            while (go)
            {


                int val = 0;
                if (int.TryParse(Console.ReadLine(), out val))
                {
                    switch (val)
                    {

                        case 1:
                            var anställda = context.Anställda
                            .Where(a => a.BefattningsId == 1)
                            .ToList();
                            foreach (var anställd in anställda)
                            {
                                Console.WriteLine($" - {anställd.Förnamn} {anställd.Efternamn}");
                            }                           
                            go = false;
                            break;

                        case 2:
                            anställda = context.Anställda
                            .Where(a => a.BefattningsId == 2)
                            .ToList();
                            foreach (var anställd in anställda)
                            {
                                Console.WriteLine($" - {anställd.Förnamn} {anställd.Efternamn}");
                            }                            
                            go = false;
                            break;
                        case 3:
                            anställda = context.Anställda
                            .Where(a => a.BefattningsId == 3)
                            .ToList();
                            foreach (var anställd in anställda)
                            {
                                Console.WriteLine($" - {anställd.Förnamn} {anställd.Efternamn}");
                            }                            
                            go = false;
                            break;
                        case 4:
                            anställda = context.Anställda
                            .Where(a => a.BefattningsId == 4)
                            .ToList();
                            foreach (var anställd in anställda)
                            {
                                Console.WriteLine($" - {anställd.Förnamn} {anställd.Efternamn}");
                            }                            
                            go = false;
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
    }
}
