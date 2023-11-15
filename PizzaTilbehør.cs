using RONEAT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RONEAT
{
    public class PizzaTilbehør
    {
        public List<Pizza.Tilbehør> tilbehørItems { get; set; }

        public PizzaTilbehør()
        {
            tilbehørItems = new List<Pizza.Tilbehør>();
            // Tilføj 5 pizza tilbehør til listen
            tilbehørItems.Add(new Pizza.Tilbehør("Ekstra ost", 10.00m));
            tilbehørItems.Add(new Pizza.Tilbehør("Chili", 5.00m));
            tilbehørItems.Add(new Pizza.Tilbehør("Hvidløg", 5.00m));
        }

        // Udskriv din liste med pizza tilbehør
        public void DisplayTilbehørMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Pizza Tilbehør:");
            Console.WriteLine("============");

            for (int i = 0; i < tilbehørItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tilbehørItems[i].Name} - {tilbehørItems[i].Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
            }

            Console.WriteLine("");
        }
    }
}

