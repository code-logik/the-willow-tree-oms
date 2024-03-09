/**
 * Mark Sarasua
 * www.code-logik.com
 * Menu.cs
 * 02 MARCH 2024
 * 
 */

using System.Collections.Generic;

namespace OMS
{
    /// <value>
    /// Named Constants <c>PERIOD</c> defines the differnt menu names.
    /// </value>
    enum PERIOD
    {
        Breakfast,
        Lunch,
        Dinner,
        OpenMenu
    }

    /// <summary>
    /// Class <c>Menu</c> provides a categorized menu with meal period options.
    /// </summary>
    internal class Menu
    {
        /// <value>
        /// Property <c>CATEGORIES</c> stores the number of menu categories.
        /// </value>
        private const int CATEGORIES = 6;

        /// <value>
        /// Property <c>_Menu</c> stores a non-periodized menu.
        /// </value>
        private List<List<MenuItem>> _Menu = new List<List<MenuItem>>();

        /// <summary>
        /// Creates a master menu.
        /// </summary>
        public Menu()
        {
            create_master_menu();
        }

        /// <summary>
        /// Current menu based on period.
        /// </summary>
        /// <param name="period">
        /// Current period.
        /// </param>
        /// <returns>
        /// Menu of specified period.
        /// </returns>
        public List<List<MenuItem>> current_menu(PERIOD period) 
        {
            List<List<MenuItem>> current = new List<List<MenuItem>>();
            switch (period) 
            {
                case PERIOD.Breakfast:
                    current = create_period_menu((int)PERIOD.Breakfast);
                    break;

                case PERIOD.Lunch:
                    current = create_period_menu((int)PERIOD.Lunch);
                    break;

                case PERIOD.Dinner:
                    current = create_period_menu((int)PERIOD.Dinner);
                    break;

                case PERIOD.OpenMenu:
                    current = _Menu;
                    break;
            }
            return current;
        }

        /// <summary>
        /// Creates a periodized menu.
        /// </summary>
        /// <param name="period">
        /// Period of menu to create.
        /// </param>
        /// <returns>
        /// Menu of specified period.
        /// </returns>
        private List<List<MenuItem>> create_period_menu(int period)
        {
            List<List<MenuItem>> menu = new List<List<MenuItem>>();
            for (int i = 0; i < CATEGORIES; i++)
            {
                menu.Add(new List<MenuItem>());
            }
            foreach (List<MenuItem> category in _Menu)
            {
                foreach (MenuItem item in category)
                {
                    if (item.Period[period] == true)
                    {
                        menu[item.Category].Add(item);
                    }
                }
            }
            return menu;
        }

        /// <summary>
        /// Creates a non-periodized master menu.
        /// </summary>
        private void create_master_menu()
        {
            MenuItems menu_items = new MenuItems();
            List<MenuItem> items = menu_items.Items;
            for (int i = 0; i < CATEGORIES; i++)
            {
                _Menu.Add(new List<MenuItem>());
            }
            foreach (MenuItem item in items)
            {
                _Menu[item.Category].Add(item);
            }
        }
    }
}
