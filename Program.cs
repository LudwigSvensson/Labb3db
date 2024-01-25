using Labb3db.Models;
using System.Linq;

namespace Labb3db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using Labb3dbContext context = new Labb3dbContext();

            Console.WriteLine("Välkommen kom till skolinfo!");
            Console.WriteLine("Välj [1] eller [2] för att se info:" +
                "\n[1]Elevlista" +
                "\n[2]Klasslista" +
                "\n[3]AdminMeny");
            var val = Console.ReadLine();
            switch (val)
            {
                //Hämtar alla elever som går på skolan
                case "1":
                    var elever = context.Elevers
                  .OrderBy(e => e.Förnamn);
                    foreach (Elever e in elever)
                    {
                        Console.WriteLine($"Name: {e.Förnamn} {e.Efternamn}");
                        Console.WriteLine(new string('-', 30));
                    }                    
                    break;
                
                //Hämtar info klasser, vilka elever som går i vilken klass osv
                case "2":
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
                    break;
                case "3":
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
                            var nyLärare = new Anställdum
                            {
                                Förnamn = fNamn,
                                Efternamn = eNamn,
                                BefattningsId = befattningsId
                            };
                            context.Anställda.Add(nyLärare);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        Console.WriteLine("FEL.");
                    }                   
                    break;

                default:
                    Console.WriteLine("FEL.");
                    break;
            }
        }
    }
}