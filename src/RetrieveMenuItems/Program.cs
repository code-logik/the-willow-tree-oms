/**
 * Mark Sarasua
 * www.code-logik.com
 * Program.cs
 * 06 MARCH 2024
 * 
 */

using System;
using System.Collections.Generic;

namespace OMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nRetrieve Menu Items Testing Tool\n\n");
            MenuItems menu_items = new MenuItems();
            List<MenuItem> menu_items_list = menu_items.Items;
            foreach (MenuItem item in menu_items_list)
            {
                Console.WriteLine
                (
                    item.Name + " " +
                    item.Image + " " +
                    item.Description + " " +
                    item.Category + " " +
                    item.Price + " " +
                    $"{item.Period[0]}, {item.Period[1]}, {item.Period[2]}"
                );
            }
            Console.WriteLine("\n\n");
            Console.ReadKey(true);
        }
    }
}
