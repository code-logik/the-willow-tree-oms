/**
 * Mark Sarasua
 * www.code-logik.com
 * MenuItem.cs
 * 01 MARCH 2024
 * 
 */

namespace OMS
{
    /// <summary>
    /// Class <c>MenuItem</c> defines the MenuItem data type.
    /// </summary>
    internal class MenuItem
    {
        /// <value>
        /// Property <c>Name</c> stores the name of the menu item.
        /// </value>
        public string Name { get; set; }

        /// <value>
        /// Property <c>Image</c> stores the location of the menu item image.
        /// </value>
        public string Image { get; set; }

        /// <value>
        /// Property <c>Description</c> stores a brief description of the menu item.
        /// </value>
        public string Description { get; set; }

        /// <value>
        /// Property <c>Category</c> stores the category code of the menu item.
        /// </value>
        public int Category { get; set; }

        /// <value>
        /// Property <c>Price</c> stores the price of the menu item.
        /// </value>
        public decimal Price { get; set; }

        /// <value>
        /// Property <c>Period</c> stores the meal periods of the menu item.
        /// </value>
        public bool[] Period { get; set; }
    }
}
