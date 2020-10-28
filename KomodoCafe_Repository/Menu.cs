using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class Menu
    {
        public string Name { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Menu() { }
        public Menu(string name, int mealNumber, string description, string ingredients, double price)
        {
            Name = name;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

    }
}
