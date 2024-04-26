/**
 * Mark Sarasua
 * www.code-logik.com
 * KMSAPI.cs
 * 03 APRIL 2024
 * 
 */

using System;
using System.Collections.Generic;

namespace OMS
{
    /// <summary>
    /// Class <c>KMSAPI</c> is a stub class for Kitchen Management System calls.
    /// </summary>
    internal class KMSAPI
    {
        /// <value>
        /// Property <c>Ordered</c> stores has ordered bool.
        /// </value>
        public bool Ordered = false;
        
        /// <summary>
        /// New order details.
        /// </summary>
        /// <returns>
        /// New order details.
        /// </returns>
        public string[] NewOrder()
        {
            // stub 
            string[] servertable = { "Elly May Clampett", "62"};
            return servertable;
        }

        /// <summary>
        /// Send order to kitchen.
        /// </summary>
        /// <param name="order">Order of type List<string>.</param>
        public void PlaceOrder(List<string> order) 
        {
            // stub
            foreach (string item in order) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
