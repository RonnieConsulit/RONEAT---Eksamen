using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RONEAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaMenu menu = new PizzaMenu();
            Bestilling bestillingObj = new Bestilling();
            bool running = true;
            int valg;

            while (running)
            {
                Console.WriteLine("Velkommen til RONEAT");
                Console.WriteLine("\nMenu:");
                Console.WriteLine("============\n");
                Console.WriteLine("1. Menu");
                Console.WriteLine("2. Indkøbsliste");
                Console.WriteLine("3. Seneste bestillinger");
                Console.WriteLine("0. Exit\n");
                Console.Write("Foretag dit valg: (indtast tallet og tryk Enter): \n");

                if (int.TryParse(Console.ReadLine(), out valg))
                {
                    switch (valg)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Du har valgt Menu.");

                            // Vis menuen
                            menu.DisplayMenu();

                            // Vil du bestille?
                            Console.WriteLine("____________________\n");
                            Console.Write("Ønsker du at bestille? (Ja/Nej): \n");
                            string svar = Console.ReadLine();
                            bestillingObj.HaandterBestilling(svar, menu.menuItems);

                            break;


                        case 2:
                            Console.Clear();
                            Console.WriteLine("Du har valgt Indkøbsliste.\n" );
                            // Print the shopping list
                            Console.WriteLine("Indkøbsliste:");
                            Console.WriteLine("============");
                            bestillingObj.DisplayBestilling();
                            Console.WriteLine("\nDu har følgende valgmuligheder:");
                            Console.WriteLine("1. Slet tilføjet Pizza");
                            Console.WriteLine("2. Bekræft bestilling");
                            Console.WriteLine("3. Gå tilbage til menu");
                            string svarSletning = Console.ReadLine();
                            bestillingObj.SletFraBestilling(svarSletning, bestillingObj.valgtePizzaer);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Du har valgt seneste bestilling.\n");
                            // Print the shopping list
                            Console.WriteLine("Seneste bestilling:");
                            Console.WriteLine("============\n");

                            bestillingObj.DisplaySeneste();
                            break;

                        default:
                            Console.WriteLine("Ugyldigt valg. Prøv igen.");
                            break;

                        case 0:
                            running = false; // Sætter 'running' til false for at afslutte løkken
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                }

                Console.WriteLine("Tryk på Enter for at fortsætte.");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}
