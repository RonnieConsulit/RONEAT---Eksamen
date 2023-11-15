using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RONEAT
{
    public class Kvittering
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public List<Pizza> ValgtePizzaer { get; set; }

        public Kvittering()
        {
            ValgtePizzaer = new List<Pizza>();
        }

        public void GenererKvittering(Bestilling bestillingObj)
        {
            Console.WriteLine("Indtast dit navn:");
            Navn = Console.ReadLine();

            Console.WriteLine("Indtast din email:");
            Email = Console.ReadLine();

            // validere email
            while (!IsValidEmail(Email))
            {
                Console.WriteLine("Indtast venligst din email igen:");
                Email = Console.ReadLine();
            }

            Console.WriteLine("Indtast din adresse:");
            Adresse = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Kvittering:");
            Console.WriteLine("===================");

            Console.WriteLine($"Kunde: {Navn}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Adresse: {Adresse}");
            Console.WriteLine("===================");


      

            foreach (var pizza in ValgtePizzaer)
            {
                bestillingObj.SenesteBestilling(pizza);
                Console.WriteLine($"{pizza.Name} - {pizza.Description} - {pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");

            }

            decimal totalPris = 0;
            foreach (var pizza in ValgtePizzaer)
            {
                totalPris += pizza.Price;
            }

            Console.WriteLine("===================");
            Console.WriteLine($"Total pris: {totalPris.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
            Console.WriteLine("===================");

            // send mail via function forneden
            SendKvitteringViaEmail();
        }

        // Formatere til txt så email kan sendes 
        private string FormatKvitteringAsText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Kvittering:");
            sb.AppendLine("===================");
            sb.AppendLine($"Kunde: {Navn}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Adresse: {Adresse}");
            sb.AppendLine("===================");

            foreach (var pizza in ValgtePizzaer)
            {
                sb.AppendLine($"{pizza.Name} - {pizza.Description} - {pizza.Price.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
            }

            decimal totalPris = 0;
            foreach (var pizza in ValgtePizzaer)
            {
                totalPris += pizza.Price;
            }

            sb.AppendLine("===================");
            sb.AppendLine($"Total pris: {totalPris.ToString("C", CultureInfo.CreateSpecificCulture("da-DK"))}");
            sb.AppendLine("===================");

            return sb.ToString();
        }

        // 
        private void SendKvitteringViaEmail()
        {
            Email emailSender = new Email();


            string subject = "Din kvittering fra RONEAT";
            string body = FormatKvitteringAsText();

            // Send e-mail
            emailSender.SendEmail(Email, subject, body);
        }

        public static bool IsValidEmail(string email)
        {
            // Define a regular expression for a simple email validation
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Check if the entered email matches the pattern
            if (Regex.IsMatch(email, emailPattern))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ugyldig email-format. Indtast venligst en gyldig email.");
                return false;
            }
        }
    }
}
