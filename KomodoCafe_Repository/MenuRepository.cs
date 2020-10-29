using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();

        // Create
        public bool AddItemToMenu(Menu item)
        {
            int startingCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Read
        public List<Menu> GetMenuList()
        {
            return _menu;
        }

        // Update
        public bool UpdateMenuItems(string originalItem, Menu newitem)
        {
            Menu oldItem = GetItemByName(originalItem);
            if (oldItem != null)
            {
                oldItem.Name = newitem.Name;
                oldItem.MealNumber = newitem.MealNumber;
                oldItem.Description = newitem.Description;
                oldItem.Ingredients = newitem.Ingredients;
                oldItem.Price = newitem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete

        public bool RemoveMenuItem(Menu existingItem)
        {
            bool removeResult = _menu.Remove(existingItem);
            return removeResult;
            /*
            Menu item = GetItemByName(existingItem);
            if (item == null)
            {
                return false;
            }
            int startingCount = _menu.Count;
            _menu.Remove(item);
            bool wasRemoved = (_menu.Count > startingCount) ? true : false;
            return wasRemoved;
            */
        }


        // Helper Method
        public Menu GetItemByName(string name)
        {
            foreach (Menu item in _menu)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
