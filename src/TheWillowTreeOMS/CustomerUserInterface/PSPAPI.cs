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
    /// Class <c>PSPAPI</c> is a stub class for Payment Service Provider calls.
    /// </summary>
    internal class PSPAPI
    {
        /// <summary>
        /// Process order.
        /// </summary>
        /// <param name="order">Order to process.</param>
        public void ProcessOrder(List<object[]> order) 
        {
            // stub
            foreach (object[] item in order) 
            {
                if (item.Length > 1) 
                {
                    foreach(object element in item) 
                    {
                        Console.Write($" {element} ");
                    }

                    Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine($"{item[0]}");
                }
            }
        }
    }
}
