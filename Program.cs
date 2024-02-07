using Labb3db.Models;
using System.Linq;

namespace Labb3db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Labb3dbContext context = Labb3dbContext.Meny();
        }        
    }
}