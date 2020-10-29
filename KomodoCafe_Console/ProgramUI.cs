using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedContent();
            ConsoleMenu();
        }

        private void ConsoleMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                // Display options to User
                Console.WriteLine("Select a menu option: \n" +
                    "1. Show Menu List\n" +
                    "2. Get Menu Item By Name\n" +
                    "3. Add Item To Menu\n" +
                    "4. Update Menu Items\n" +
                    "5. Remove Menu Item\n" +
                    "6. Exit");

                //Get User's Input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        ShowMenuItemByName();
                        break;
                    case "3":
                        CreateNewItem();
                        break;
                    case "4":
                        UpdateItem();
                        break;
                    case "5":
                        RemoveItem();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        // Create new Menu Item
        private void CreateNewItem()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();
            Console.WriteLine("Enter the name of the new item:");
            newMenuItem.Name = Console.ReadLine();
            Console.WriteLine("Enter the number of the item:");
            newMenuItem.MealNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the description of the item:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the ingredients of the item:");
            newMenuItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter the price of the item:");
            newMenuItem.Price = Double.Parse(Console.ReadLine());

            bool wasAdded = _menuRepo.AddItemToMenu(newMenuItem);
            if (wasAdded == true)
            {
                Console.WriteLine("New Item succesfully added to Menu.");
            }
            else
            {
                Console.WriteLine("Something went wrong. Item was not added to Menu.");
            }

            
        }
        // View Menu
        private void DisplayMenu()
        {
            List<Menu> menuList = _menuRepo.GetMenuList();
            foreach(Menu item in menuList)
            {
                DisplayMenu(item);
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        // Get Menu item by name
        private void ShowMenuItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the item you would like to see:");
            string name = Console.ReadLine();

            Menu menuItem = _menuRepo.GetItemByName(name);

            if (menuItem != null)
            {
                DisplayMenu(menuItem);
            }
            else
            {
                Console.WriteLine("That item doesn't exist");
            }
            Console.ReadKey();
        }

        // Update Menu Item
        private void UpdateItem()
        {
            // display menu
            DisplayMenu();
            // ask for item to update
            Console.WriteLine("Enter the name of the item you would like to update.");
            // get that item
            string name = Console.ReadLine();
            Menu oldItem = _menuRepo.GetItemByName(name);

            // build a new item
            if (oldItem == null)
            {
                Console.WriteLine("Content not found, press any key to continue...");
                Console.ReadKey();
                return;
            }
            Menu newMenuItem = new Menu(
                oldItem.Name,
                oldItem.MealNumber,
                oldItem.Description,
                oldItem.Ingredients,
                oldItem.Price);

            Console.WriteLine("Enter the name of the new item:");
            newMenuItem.Name = Console.ReadLine();
            Console.WriteLine("Enter the number of the item:");
            newMenuItem.MealNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the description of the item:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the ingredients of the item:");
            newMenuItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter the price of the item:");
            newMenuItem.Price = Double.Parse(Console.ReadLine());

            bool wasUpdated = _menuRepo.UpdateMenuItems(name, newMenuItem);
            if (wasUpdated == true)
            {
                Console.WriteLine("Item succesfully updated.");
            }
            else
            {
                Console.WriteLine("Something went wrong. Item was not updated.");
            }
        }

        // Remove Menu Item
        private void RemoveItem()
        {
            DisplayMenu();
            Console.WriteLine("Enter the name of the item you would like to remove.");
            string nameToRemove = Console.ReadLine();

            Menu itemToRemove = _menuRepo.GetItemByName(nameToRemove);
            bool wasRemoved = _menuRepo.RemoveMenuItem(itemToRemove);
            if (wasRemoved)
            {
                Console.WriteLine("Item successfully removed from menu.");
            }
            else
            {
                Console.WriteLine("Item could not be deleted.");
            }
            Console.ReadLine();

        }

        private void DisplayMenu(Menu menuItem)
        {
            Console.WriteLine($"Name: {menuItem.Name}");
            Console.WriteLine($"Number: {menuItem.MealNumber}");
            Console.WriteLine($"Description: {menuItem.Description}");
            Console.WriteLine($"Ingredients: {menuItem.Ingredients}");
            Console.WriteLine($"Price: {menuItem.Price}");
            Console.WriteLine("\n");
        }
        private void SeedContent()
        {
            Menu chickenBurrito = new Menu("Chicken Burrito", 1, "Shredded chicken wrapped in a Tortilla", "Chicken, Rice, Beans, Cheese, Lettuce and Salsa", 7.15);
            Menu steakTacos = new Menu("Steak Tacos", 2, "Strip steak inside 3 hard tacos", "Steak, Cheese, Lettuce, Cilantro and Lime juice", 8.99);

            _menuRepo.AddItemToMenu(chickenBurrito);
            _menuRepo.AddItemToMenu(steakTacos);
        }
    }
}
