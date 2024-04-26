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
        Dinner
    }

    /// <summary>
    /// Class <c>Menu</c> provides a categorized menu with meal period options.
    /// </summary>
    internal class Menu
    {
        /// <value>
        /// Property <c>_CATEGORIES</c> stores the number of menu categories.
        /// </value>
        private const int _CATEGORIES = 4;

        /// <value>
        /// Property <c>_Menu</c> stores a non-periodized menu.
        /// </value>
        private List<MenuItem> _Menu = new List<MenuItem>();

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
        /// <param name="period">Current period.</param>
        /// <returns>
        /// Menu of specified period.
        /// </returns>
        public List<MenuItem> current_menu(PERIOD period) 
        {
            List<MenuItem> current = new List<MenuItem>();
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
            }
            return current;
        }

        /// <summary>
        /// Creates a periodized menu.
        /// </summary>
        /// <param name="period">Period of menu to create.</param>
        /// <returns>
        /// Menu of specified period.
        /// </returns>
        private List<MenuItem> create_period_menu(int period)
        {
            List<MenuItem> menu = new List<MenuItem>();
            foreach (MenuItem item in _Menu)
            {
                if (item.PERIOD[period] == true)
                {
                    menu.Add(item);
                }
            }
            return menu;
        }

        /// <summary>
        /// Creates a non-periodized master menu.
        /// </summary>
        private void create_master_menu()
        {
            MenuItems menuitems = new MenuItems();
            _Menu = menuitems.Items;
        }
    }
}
