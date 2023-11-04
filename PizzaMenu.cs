using RONEAT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RONEAT
{
    public class PizzaMenu
    {
        public List<Pizza> menuItems { get; set; }
        public PizzaMenu()
        {
            menuItems = new List<Pizza>();
            // Tilføj 10 pizzaer til listen
            menuItems.Add(new Pizza("Pepperoni Pizza", "Klassisk pepperoni med mozzarellaost", 75.00m));
            menuItems.Add(new Pizza("Margherita Pizza", "Tomatsauce, frisk mozzarella og basilikum", 65.00m));
            menuItems.Add(new Pizza("Vegetarisk Pizza", "Forskellige grøntsager og mozzarellaost", 70.00m));
            menuItems.Add(new Pizza("Supreme Pizza", "Pepperoni, pølse, peberfrugter, løg og champignoner", 80.00m));
            menuItems.Add(new Pizza("Hawaii Pizza", "Skinke, ananas og mozzarellaost", 70.00m));
            menuItems.Add(new Pizza("BBQ Kylling Pizza", "Grillet kylling, BBQ-sauce og rødløg", 75.00m));
            menuItems.Add(new Pizza("Mushroom Lovers Pizza", "Champignon, mozzarellaost og hvidløg", 70.00m));
            menuItems.Add(new Pizza("Kødelskere Pizza", "Pepperoni, pølse, bacon og skinke", 80.00m));
            menuItems.Add(new Pizza("Grøntsagsfest Pizza", "Forskellige grøntsager og mozzarellaost", 70.00m));
            menuItems.Add(new Pizza("Oste Pizza", "Mozzarella, cheddar, parmesan og fetaost", 75.00m));
        }

        // Udskriv din liste med pizzaer
        public void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Pizza Menu:");
            Console.WriteLine("============");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i].Name} - {menuItems[i].Description} - {menuItems[i].Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
            }
        } 
    }
}
