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
            Console.WriteLine("\n\nView Menu Testing Tool\n\n");

            Menu menu = new Menu();
            List<List<MenuItem>> current_menu = new List<List<MenuItem>>();

            Console.WriteLine("Breakfast Menu\n");
            current_menu = menu.current_menu(PERIOD.Breakfast);
            foreach (List<MenuItem> category in current_menu)
            {
                foreach (MenuItem item in category)
                {
                    Console.WriteLine
                    (
                        $"  {Convert.ToInt32(item.Period[0])}  " +
                        $"  {Convert.ToInt32(item.Period[1])}  " +
                        $"  {Convert.ToInt32(item.Period[2])}  " +
                        $"  {item.Name}  " +
                        $"  {item.Description}  " +
                        $"  {item.Price}  "
                    );
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Lunch Menu\n");
            current_menu = menu.current_menu(PERIOD.Lunch);
            foreach (List<MenuItem> category in current_menu)
            {
                foreach (MenuItem item in category)
                {
                    Console.WriteLine
                    (
                        $"  {Convert.ToInt32(item.Period[0])}  " +
                        $"  {Convert.ToInt32(item.Period[1])}  " +
                        $"  {Convert.ToInt32(item.Period[2])}  " +
                        $"  {item.Name}  " +
                        $"  {item.Description}  " +
                        $"  {item.Price}  "
                    );
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Dinner Menu\n");
            current_menu = menu.current_menu(PERIOD.Dinner);
            foreach (List<MenuItem> category in current_menu)
            {
                foreach (MenuItem item in category)
                {
                    Console.WriteLine
                    (
                        $"  {Convert.ToInt32(item.Period[0])}  " +
                        $"  {Convert.ToInt32(item.Period[1])}  " +
                        $"  {Convert.ToInt32(item.Period[2])}  " +
                        $"  {item.Name}  " +
                        $"  {item.Description}  " +
                        $"  {item.Price}  "
                    );
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Open Menu\n");
            current_menu = menu.current_menu(PERIOD.OpenMenu);
            foreach (List<MenuItem> category in current_menu)
            {
                foreach (MenuItem item in category)
                {
                    Console.WriteLine
                    (
                        $"  {Convert.ToInt32(item.Period[0])}  " +
                        $"  {Convert.ToInt32(item.Period[1])}  " +
                        $"  {Convert.ToInt32(item.Period[2])}  " +
                        $"  {item.Name}  " +
                        $"  {item.Description}  " +
                        $"  {item.Price}  "
                    );
                }
            }

            Console.WriteLine("\n\n");
            Console.ReadKey(true);
        }
    }
}
