using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RONEAT
{

    public class Pizza
    {

        // Instance variable (gør vi kan hente og sidde) 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        // Constructer (skal bestå af)
        public Pizza(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public class Tilbehør
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Tilbehør(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
    }

}

