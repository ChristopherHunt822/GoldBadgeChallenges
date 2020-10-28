using System;
using System.Collections.Generic;
using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class Menu_RepoTests
    {
        [TestMethod]
        public void AddItemToMenu_ShouldGetCorrectBoolean()
        {
            //Arrange
            Menu item = new Menu();
            MenuRepository menuRepository = new MenuRepository();
            //Act
            bool addItem = menuRepository.AddItemToMenu(item);
            //Assert
            Assert.IsTrue(addItem);
        }
        [TestMethod]
        public void GetMenuList_ShouldReturnMenu()
        {
            Menu item = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddItemToMenu(item);

            List<Menu> menu = repo.GetMenuList();
            bool menuHasContent = menu.Contains(item);

            Assert.IsTrue(menuHasContent);
        }
        [TestMethod]
        public void UpdateMenuItems_ShouldReturnTrue()
        {
            MenuRepository repo = new MenuRepository();
            Menu oldItem = new Menu("burger", 1, "beef patty on bun", "lettuce, tomato, mayo, ketchup", 4.99);
            repo.AddItemToMenu(oldItem);
            Menu newItem = new Menu("double cheeseburger", 1, "2 beef patties on bun", "lettuce, tomato, mayo, ketchup", 5.99);

            bool updateResult = repo.UpdateMenuItems(oldItem.Name, newItem);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void RemoveMenuItem_ShouldReturnTrue()
        {
            MenuRepository repo = new MenuRepository();
            Menu item = new Menu("burger", 1, "beef patty on bun", "lettuce, tomato, mayo, ketchup", 4.99);
            repo.AddItemToMenu(item);

            Menu oldItem = repo.GetItemByName("burger");
            bool removeItem = repo.RemoveMenuItem(oldItem);

            Assert.IsTrue(removeItem);


        }
       
    }
}
