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
        public Pizza[] senesteBestillinger { get; set; }

        public Kvittering kvittering { get; set; }



        public Bestilling()
        {
            valgtePizzaer = new List<Pizza>();
            menuKort = new List<Pizza>();
            senesteBestillinger = Enumerable.Repeat(new Pizza("Ingen bestilling", "Ingen beskrivelse", 0.00m), 10).ToArray();
            kvittering = new Kvittering();
        }


        public void HaandterBestilling(string svar, List<Pizza> menuKort)

        {
            bool gyldigtSvar = false;

            while (!gyldigtSvar)
            {
                if (svar.ToLower() == "ja")
                {
                    Console.WriteLine("\nIndtast nummeret på den ønskede pizza, efterfulgt af enter:");
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
                    Console.WriteLine("Ugyldigt svar. Vælg enten 'Ja' eller 'Nej'.");
                    svar = Console.ReadLine();
                    continue;
                }
            }
        }

        public void vaelgPizza(List<Pizza> inputList)
        {
            int pizzaValg;
            if (int.TryParse(Console.ReadLine(), out pizzaValg))
            {

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
                    Console.WriteLine("\nØnsker du at tilføje tilbehør til din pizza? (Ja/Nej)");
                    string tilføjTilbehørSvar = Console.ReadLine();
                    TilføjTilbehør(tilføjTilbehørSvar);
                    Console.WriteLine("\nFor at tilføje endnu en pizza til din kurv, åben menu og gentag.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg. Vælg en gyldig pizza fra menuen.");
                }
            }
        }

        public void SletFraBestilling(string svarSletning, List<Pizza> valgtePizzaer)

        {
            bool gyldigtSvar = false;

            while (!gyldigtSvar)
            {

                if (svarSletning == "1")
                {
                    if (valgtePizzaer.Count > 0)
                    {
                        Console.WriteLine("\nDu har valgt at slette en pizza. Indtast nummeret på den ønskede pizza efterfulgt af enter\n");
                        int onsketSletning = Convert.ToInt32(Console.ReadLine());

                        if (onsketSletning >= 1 && onsketSletning <= valgtePizzaer.Count)
                        {
                            // Slet pizzaer fra liste
                            valgtePizzaer.RemoveAt(onsketSletning - 1);
                            Console.WriteLine("\nPizzaen er blevet slettet fra din bestilling.\n");
                        }

                        else
                        {
                            Console.WriteLine("\nUgyldigt valg. Vælg en gyldig pizza fra din bestilling.\n");
                        }

                        gyldigtSvar = true;
                    }
                    else if (valgtePizzaer.Count <= 0)
                    {
                        Console.WriteLine("\nIndkøbskurv tom, går tilbage til menu!");
                        gyldigtSvar = true;
                    }
                }



                else if (svarSletning == "2")
                {


                    if (valgtePizzaer.Count > 0)
                    {
                        Console.WriteLine("\nDu har valgt at bekræfte bestilling. Tak!");
                        Bestilling bestillingObj = new Bestilling();
                        kvittering.ValgtePizzaer = valgtePizzaer;
                        kvittering.GenererKvittering(bestillingObj);

                        foreach (var valgtePizza in valgtePizzaer)
                        {
                            SenesteBestilling(valgtePizza);
                        }
                        // Nulstil bestilling efter kvittering
                        valgtePizzaer.Clear();

                        gyldigtSvar = true;
                    }
                    else if (valgtePizzaer.Count <= 0)
                    {
                        Console.WriteLine("\nIndkøbskurv tom, går tilbage til menu!");
                        gyldigtSvar = true;
                    }

                }
                else if (svarSletning == "3")
                {
                    Console.WriteLine("\nDu har valgt at gå tilbage til menuen.\n");
                    gyldigtSvar = true;
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg. Vælg en af de angivne muligheder.");
                    break;
                }
            }
        }
        public void TilføjTilbehør(string svarTilbehør)
        {
            bool gyldigtSvar = false;




            if (svarTilbehør.ToLower() == "ja")
            {
                Console.WriteLine("Du har følgende valgmuligheder:\n");
                PizzaTilbehør tilbehørObj = new PizzaTilbehør();

                while (!gyldigtSvar)
                {
                    Console.Clear();
                    tilbehørObj.DisplayTilbehørMenu();
                    int tilbehørValg;
                    Console.WriteLine("Vælg et nummer efterfulgt af enter.:");

                    if (int.TryParse(Console.ReadLine(), out tilbehørValg) && tilbehørValg >= 1 && tilbehørValg <= tilbehørObj.tilbehørItems.Count)
                    {

                        // Minus 1 for at passe med liste index
                        valgtePizzaer.Last().Name += $" + {tilbehørObj.tilbehørItems[tilbehørValg - 1].Name}";
                        valgtePizzaer.Last().Price += tilbehørObj.tilbehørItems[tilbehørValg - 1].Price;
                        Console.WriteLine($"\n{tilbehørObj.tilbehørItems[tilbehørValg - 1].Name} valgt - Vil du tilføje mere tilbehør? (Ja/Nej)");

                        // til quit
                        svarTilbehør = Console.ReadLine();
                        if (svarTilbehør.ToLower() == "nej")
                        {
                            Console.WriteLine("\nDine har valgt følgende:");
                            Console.WriteLine($"{valgtePizzaer.Last().Name} - {valgtePizzaer.Last().Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
                            gyldigtSvar = true;
                        }
                        else
                        {

                        }
                    }

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Går tilbage til menu.");
            }
        }



        public void DisplayBestilling()
        {
            int count = 1;
            foreach (var pizza in valgtePizzaer)
            {
                // counter til at give overblik og liste med pizzer
                Console.WriteLine($"{count}. - {pizza.Name} - {pizza.Description} - {pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
                count++;
            }
        }

            public void SenesteBestilling(Pizza pizza)
            {
                // Move elements in the array down by one position
                for (int i = senesteBestillinger.Length - 1; i > 0; i--)
                {
                    senesteBestillinger[i] = senesteBestillinger[i - 1];
                }

                // Add the new pizza to the beginning of the array
                senesteBestillinger[0] = pizza;
            }



        public void DisplaySeneste()
        {
            // counter til at give overblik og liste med pizzer
            int count = 1;
            foreach (var pizza in senesteBestillinger)
            { 
                    Console.WriteLine($"{count}. - {pizza.Name} - {pizza.Description} - {pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
                    count++;

            }
            Console.WriteLine();
        }

    }
}
