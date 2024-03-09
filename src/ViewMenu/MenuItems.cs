/**
 * Mark Sarasua
 * www.code-logik.com
 * MenuItems.cs
 * 01 MARCH 2024
 * 
 */

using System.Collections.Generic;

namespace OMS
{
    /// <summary>
    /// Class <c>MenuItems</c> provides a collection of the MenuItem data type.
    /// </summary>
    internal class MenuItems
    {
        /// <value>
        /// Property <c>_Database</c> initializes an instance of the Database Class.
        /// </value>
        private Database _Database = new Database();

        /// <value>
        /// Property <c>_Items</c> stores a List of MenuItem.
        /// </value>
        private List<MenuItem> _Items = new List<MenuItem>();

        /// <value>
        /// Property <c>Items</c> provides read access to _Items.
        /// </value>
        public List<MenuItem> Items
        {
            get { return _Items; }
        }

        /// <summary>
        /// Creates the database and reads it into _Items.
        /// </summary>
        public MenuItems()
        {
            _Database.create();
            _Items = _Database.read();
        }
    }
}
