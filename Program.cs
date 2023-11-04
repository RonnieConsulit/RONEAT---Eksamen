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
                Console.WriteLine("____________________\n");
                Console.WriteLine("1. Menu");
                Console.WriteLine("2. Indkøbsliste");
                Console.WriteLine("0. Exit\n");
                Console.Write("Foretag dit valg: (indtast tallet og tryk Enter): ");

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
                            Console.WriteLine("Ønsker du at slette noget fra din bestilling? (Ja/Nej): \n");
                            string svarSletning = Console.ReadLine();
                            bestillingObj.SletFraBestilling(svarSletning, bestillingObj.valgtePizzaer);
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
