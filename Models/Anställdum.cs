using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public static void SkapaNyAnställd(Labb3dbContext context)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till skapa en helt ny anställd!" +
                "\nFör att skapa en anställd börja med att skriva in hens förnamn: ");
            string fNamn = Console.ReadLine();

            Console.WriteLine("Nu skriver du in hens efternamn: ");
            string eNamn = Console.ReadLine();

            Console.WriteLine("Här har du möjligheten att välja vilken typ av beffattning din anställda ska ha" +
                "\n[1]Lärare" +
                "\n[2]Vaktmästare" +
                "\n[3]Rektor" +
                "\n[4]Receptionist");
            var befattningsval = Console.ReadLine();
            //switch (befattningsval)
            //{
            //    case "1":                            
            //        break;
            //    case "2":                           
            //        break;
            //    case "3":                            
            //        break;
            //    case "4":                            
            //        break;
            //    default:
            //        Console.WriteLine("FEL. Du MÅSTE välja en av de beffatningar som finns i listan" +
            //            "\n [1],[2],[3] eller [4]");
            //        break;
            //}
            if (int.TryParse(befattningsval, out int befattningsId))
            {
                var finnsBefattningsId = context.Befattningars.Find(befattningsId);
                if (finnsBefattningsId != null)
                {
                    var nyAnställd = new Anställdum
                    {
                        Förnamn = fNamn,
                        Efternamn = eNamn,
                        BefattningsId = befattningsId
                    };
                    context.Anställda.Add(nyAnställd);
                    Console.WriteLine($"Ny anställd med namn: {nyAnställd.Förnamn} {nyAnställd.Efternamn} är skapad" +
                        $"\nTryck Enter för att spara och återgå till meny");
                    Console.ReadKey();
                    context.SaveChanges();
                    Console.Clear();

                }
            }
            else
            {
                Console.WriteLine("FEL.");
            }
        }

                
    }
}
