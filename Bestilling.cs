using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RONEAT
{
    public class Bestilling
    {
        public List<Pizza> valgtePizzaer { get; set; }
        public List<Pizza> menuKort { get; set; }


        public Bestilling() 
        {
            valgtePizzaer = new List<Pizza>();
            menuKort = new List<Pizza>();
        }


        public void HaandterBestilling(string svar, List<Pizza> menuKort)

        {
            bool gyldigtSvar = false;

            while (!gyldigtSvar)
            {
                if (svar.ToLower() == "ja")
                {
                    Console.WriteLine("\nIndtast nummeret på den ønskede pizza, efterfulgt af enter:\n");
                    vaelgPizza(menuKort);
                    gyldigtSvar = true;
                }
                else if (svar.ToLower() == "nej")
                {
                    Console.WriteLine("\nDu har skrevet nej, vender tilbage til menu.\n");
                    gyldigtSvar = true;
                }
                else
                {
                    Console.WriteLine("\nUgyldigt svar. Vælg enten 'Ja' eller 'Nej'.\n");
                    svar = Console.ReadLine();
                    continue;
                }
            }
        }

        public void vaelgPizza(List<Pizza> inputList)
        {
            int pizzaValg = Convert.ToInt32(Console.ReadLine());

            
            if (pizzaValg >= 1 && pizzaValg <= inputList.Count)
            {   
                // minus 1 for at liste skal passe med listegrænser 
                Pizza valgtPizza = inputList[pizzaValg - 1];

                Console.WriteLine();
                Console.WriteLine($"Du har valgt: {valgtPizza.Name}");
                Console.WriteLine($"Beskrivelse: {valgtPizza.Description}");
                Console.WriteLine($"Pris: {valgtPizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");

                // tilføjer pizza til listen
                valgtePizzaer.Add(valgtPizza); 

                Console.WriteLine("\nTak for din bestilling!");
                Console.WriteLine("For at tilføje endnu en pizza til din kurv, åben menu og gentag.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Vælg en gyldig pizza fra menuen.");
            }
        }

        public void SletFraBestilling(string svarSletning, List<Pizza> valgtePizzaer)

        {
            bool gyldigtSvar = false;

            while (!gyldigtSvar)
            {
                if (svarSletning.ToLower() == "ja")
                {
                    Console.WriteLine("\nDu har valgt ja, indtast nummer, der ønskes slettet efterfulgt af enter\n");
                    int onsketSletning = Convert.ToInt32(Console.ReadLine());

                    if (onsketSletning >= 1 && onsketSletning <= valgtePizzaer.Count)
                    {
                        // Remove the selected pizza from the list
                        valgtePizzaer.RemoveAt(onsketSletning - 1);
                        Console.WriteLine("\nPizzaen er blevet slettet fra din bestilling.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nUgyldigt valg. Vælg en gyldig pizza fra din bestilling.\n");
                    }
                    gyldigtSvar = true;
                }
                else if (svarSletning.ToLower() == "nej")
                {
                    Console.WriteLine("\nDu har skrevet nej, vender tilbage til menu.\n");
                    gyldigtSvar = true;
                }
                else
                {
                    Console.WriteLine("\nUgyldigt valg. Vælg en gyldig pizza fra menuen.");
                    continue;
                }
            }
        }

        public void DisplayBestilling()
        {
            foreach (var pizza in valgtePizzaer)
            {
                // counter til at give overblik og liste med pizzer
                int count = 1;
                Console.WriteLine($"{count}. - {pizza.Name} - {pizza.Description} - {pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}\n");
                count++;
            }
        }

    }
}
