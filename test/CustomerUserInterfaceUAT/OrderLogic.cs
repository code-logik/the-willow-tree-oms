/**
 * Mark Sarasua
 * www.code-logik.com
 * OrderLogic.cs
 * 02 APRIL 2024
 * 
 */

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace CustomerUserInterface
{
    /// <summary>
    /// Partial Class <c>MainWindow</c> file OrderLogic.cs provides the logic associated with Order events.  
    /// </summary>
    partial class MainWindow
    {
        /// <value>
        /// Property <c>_Order</c> stores List of type OMS.MenuItem.
        /// </value>
        private List<OMS.MenuItem> _Order = new List<OMS.MenuItem>();

        /// <value>
        /// Property <c>_SALES_TAX</c> stores the sales tax percentage.
        /// </value>
        private const decimal _SALES_TAX = 0.0877M;

        /// <value>
        /// Property <c>_Tip</c> stores tip amount.
        /// </value>
        private decimal _Tip = 0M;

        /// <value>
        /// Property <c>_SubTotal</c> stores the subtotal amount.
        /// </value>
        private decimal _SubTotal = 0M;

        /// <value>
        /// Property <c>_Sales_Tax</c> stores the sales tax amount.
        /// </value>
        private decimal _Sales_Tax = 0M;

        /// <value>
        /// Property <c>_Total</c> stores the total amount.
        /// </value>
        private decimal _Total = 0M;

        /// <value>
        /// Property <c>_Balance_Due</c> stores the balance due amount.
        /// </value>
        private decimal _Balance_Due = 0M;

        /// <value>
        /// Property <c>_Server</c> stores the server name.
        /// </value>
        private string _Server = "Florence Castleberry";

        /// <value>
        /// Property <c>_Table</c> stores the table number.
        /// </value>
        private string _Table = "81";

        /// <summary>
        /// Adds structured calculated order data to Order xaml.
        /// </summary>
        /// <returns>
        /// Grid layout of calculated order data.
        /// </returns>
        private Grid AddTotals()
        {
            _SubTotal = CalculateSubTotal();
            _Sales_Tax = Math.Round(_SubTotal * _SALES_TAX, 2);
            _Total = _SubTotal + _Sales_Tax;
            _Balance_Due = _Total + _Tip;

            Grid grid = new Grid
            {
                Name = "TOTALS",
                Width = 245,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();
            RowDefinition row6 = new RowDefinition();
            RowDefinition row7 = new RowDefinition();
            RowDefinition row8 = new RowDefinition();

            col1.Width = new GridLength(107);
            col2.Width = new GridLength(6);
            col3.Width = new GridLength(76);
            col4.Width = new GridLength(50);
            col5.Width = new GridLength(6);

            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions.Add(col3);
            grid.ColumnDefinitions.Add(col4);
            grid.ColumnDefinitions.Add(col5);

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            grid.RowDefinitions.Add(row3);
            grid.RowDefinitions.Add(row4);
            grid.RowDefinitions.Add(row5);
            grid.RowDefinitions.Add(row6);
            grid.RowDefinitions.Add(row7);
            grid.RowDefinitions.Add(row8);

            TextBlock top_horizontal_line = new TextBlock
            {
                Text = "--------------------------------------------------",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock subtotal_label = new TextBlock
            {
                Text = "SUBTOTAL",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock subtotal_value = new TextBlock
            {
                Text = _SubTotal.ToString("F", CultureInfo.CurrentCulture),
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock sales_tax_label = new TextBlock
            {
                Text = "TAX (8.77%)",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock sales_tax_value = new TextBlock
            {
                Text = _Sales_Tax.ToString("F", CultureInfo.CurrentCulture),
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock total_label = new TextBlock
            {
                Text = "TOTAL",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock total_value = new TextBlock
            {
                Text = _Total.ToString("F", CultureInfo.CurrentCulture),
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock middle_horizontal_line = new TextBlock
            {
                //     -1234567890123456789012345678-
                Text = "----------------------------",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock tip_label = new TextBlock
            {
                Text = "TIP",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock tip_value = new TextBlock
            {
                Text = _Tip.ToString("F", CultureInfo.CurrentCulture),
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock bottom_horizontal_line = new TextBlock
            {
                Text = "----------------------------",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock balance_due_label = new TextBlock
            {
                Text = "BALANCE",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock balance_due_value = new TextBlock
            {
                Text = _Balance_Due.ToString("C", CultureInfo.CurrentCulture),
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumnSpan(top_horizontal_line, 5);
            Grid.SetColumnSpan(middle_horizontal_line, 4);
            Grid.SetColumnSpan(bottom_horizontal_line, 4);

            Grid.SetColumn(top_horizontal_line, 0);
            Grid.SetColumn(subtotal_label, 2);
            Grid.SetColumn(subtotal_value, 3);
            Grid.SetColumn(sales_tax_label, 2);
            Grid.SetColumn(sales_tax_value, 3);
            Grid.SetColumn(total_label, 2);
            Grid.SetColumn(total_value, 3);
            Grid.SetColumn(middle_horizontal_line, 1);
            Grid.SetColumn(tip_label, 2);
            Grid.SetColumn(tip_value, 3);
            Grid.SetColumn(bottom_horizontal_line, 1);
            Grid.SetColumn(balance_due_label, 2);
            Grid.SetColumn(balance_due_value, 3);

            Grid.SetRow(top_horizontal_line, 0);
            Grid.SetRow(subtotal_label, 1);
            Grid.SetRow(subtotal_value, 1);
            Grid.SetRow(sales_tax_label, 2);
            Grid.SetRow(sales_tax_value, 2);
            Grid.SetRow(total_label, 3);
            Grid.SetRow(total_value, 3);
            Grid.SetRow(middle_horizontal_line, 4);
            Grid.SetRow(tip_label, 5);
            Grid.SetRow(tip_value, 5);
            Grid.SetRow(bottom_horizontal_line, 6);
            Grid.SetRow(balance_due_label, 7);
            Grid.SetRow(balance_due_value, 7);

            grid.Children.Add(top_horizontal_line);
            grid.Children.Add(subtotal_label);
            grid.Children.Add(subtotal_value);
            grid.Children.Add(sales_tax_label);
            grid.Children.Add(sales_tax_value);
            grid.Children.Add(total_label);
            grid.Children.Add(total_value);
            grid.Children.Add(middle_horizontal_line);
            grid.Children.Add(tip_label);
            grid.Children.Add(tip_value);
            grid.Children.Add(bottom_horizontal_line);
            grid.Children.Add(balance_due_label);
            grid.Children.Add(balance_due_value);

            RemoveTotals();
            return grid;
        }

        /// <summary>
        /// Adds structured header data to Order xaml.
        /// </summary>
        /// <returns>
        /// Grid layout of header data.
        /// </returns>
        private Grid Header()
        {
            Grid grid = new Grid
            {
                Width = 245,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();

            col1.Width = new GridLength(6);
            col2.Width = new GridLength(50);
            col3.Width = new GridLength(183);
            col4.Width = new GridLength(6);

            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions.Add(col3);
            grid.ColumnDefinitions.Add(col4);

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            grid.RowDefinitions.Add(row3);
            grid.RowDefinitions.Add(row4);
            grid.RowDefinitions.Add(row5);

            TextBlock top_line = new TextBlock
            {
                Text = "--------------------------------------------------",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock date_label = new TextBlock
            {
                Text = "Date:",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock date_value = new TextBlock
            {
                Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock server_label = new TextBlock
            {
                Text = "Server:",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock server_value = new TextBlock
            {
                Text = _Server,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock table_label = new TextBlock
            {
                Text = "Table:",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock table_value = new TextBlock
            {
                Text = _Table,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock bottom_line = new TextBlock
            {
                Text = "--------------------------------------------------",
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumnSpan(top_line, 4);
            Grid.SetColumnSpan(bottom_line, 4);

            Grid.SetColumn(top_line, 0);
            Grid.SetColumn(date_label, 1);
            Grid.SetColumn(date_value, 2);
            Grid.SetColumn(server_label, 1);
            Grid.SetColumn(server_value, 2);
            Grid.SetColumn(table_label, 1);
            Grid.SetColumn(table_value, 2);
            Grid.SetColumn(bottom_line, 0);

            Grid.SetRow(top_line, 0);
            Grid.SetRow(date_label, 1);
            Grid.SetRow(date_value, 1);
            Grid.SetRow(server_label, 2);
            Grid.SetRow(server_value, 2);
            Grid.SetRow(table_label, 3);
            Grid.SetRow(table_value, 3);
            Grid.SetRow(bottom_line, 4);

            grid.Children.Add(top_line);
            grid.Children.Add(date_label);
            grid.Children.Add(date_value);
            grid.Children.Add(server_label);
            grid.Children.Add(server_value);
            grid.Children.Add(table_label);
            grid.Children.Add(table_value);
            grid.Children.Add(bottom_line);

            RemoveHeader();
            return grid;
        }

        /// <summary>
        /// Calculates subtotal.
        /// </summary>
        /// <returns>
        /// Subtotal of type decimal.
        /// </returns>
        private decimal CalculateSubTotal()
        {
            decimal subtotal = 0;
            
            foreach (OMS.MenuItem item in _Order)
            {
                subtotal += item.PRICE;
            }

            return subtotal;
        }

        /// <summary>
        /// Removes calculated order data from Order xaml.
        /// </summary>
        private void RemoveTotals()
        {
            OrderTotal.Children.Clear();
        }

        /// <summary>
        /// Removes header data from Order xaml.
        /// </summary>
        private void RemoveHeader()
        {
            OrderHead.Children.Clear();
        }
    }
}
