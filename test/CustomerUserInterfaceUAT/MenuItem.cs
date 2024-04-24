/**
 * Mark Sarasua
 * www.code-logik.com
 * MenuItem.cs
 * 01 MARCH 2024
 * 
 */

using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OMS
{
    /// <summary>
    /// Static class <c>MenuItemExtensions</c> extends MenuItem class. 
    /// </summary>
    internal static class MenuItemExtensions 
    {
        /// <summary>
        /// Creates a deep copy of type MenuItem.
        /// </summary>
        /// <typeparam name="MenuItem">Type MenuItem.</typeparam>
        /// <param name="self">Self</param>
        /// <returns></returns>
        public static MenuItem DeepCopy<MenuItem>(this MenuItem self) 
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<MenuItem>(serialized);
        }
    }

    /// <summary>
    /// Class <c>MenuItem</c> defines the MenuItem data type.
    /// </summary>
    internal class MenuItem
    {
        /// <value>
        /// Property <c>_MenuItemButton</c> stores the OMSMenuItemButton Style xaml.
        /// </value>
        private Style _MenuItemButton = Application.Current.FindResource("OMSMenuItemButton") as Style;

        /// <value>
        /// Property <c>_White_Smoke</c> stores the white smoke color.
        /// </value>
        private Color _White_Smoke = (Color)ColorConverter.ConvertFromString("#FFF5F5F5");

        /// <value>
        /// Property <c>_ASSETS_DIRECTORY</c> stores the directory name.
        /// </value>
        private const string _ASSETS_DIRECTORY = "Assets";

        /// <value>
        /// Property <c>_IMAGES_DIRECTORY</c> stores the directory name.
        /// </value>
        private const string _IMAGES_DIRECTORY = "Images";

        /// <value>
        /// Property <c>_Path</c> stores the image directory path.
        /// </value>
        private static string _Path = null;

        /// <value>
        /// Property <c>Category</c> stores the category code of the menu item.
        /// </value>
        public int CATEGORY { get; set; }

        /// <value>
        /// Property <c>Name</c> stores the name of the menu item.
        /// </value>
        public string NAME { get; set; }

        /// <value>
        /// Property <c>Price</c> stores the price of the menu item.
        /// </value>
        public decimal PRICE { get; set; }

        /// <value>
        /// Property <c>Image</c> stores the location of the menu item image.
        /// </value>
        public string IMAGE { get; set; }

        /// <value>
        /// Property <c>Period</c> stores the meal periods of the menu item.
        /// </value>
        public bool[] PERIOD { get; set; }


        /// <summary>
        /// Adds structured MenuItem data to Order xaml.
        /// </summary>
        /// <returns>
        /// Grid layout of MenuItem data.
        /// </returns>
        public Grid AddItem()
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
            ColumnDefinition col5 = new ColumnDefinition();

            col1.Width = new GridLength(6);
            col2.Width = new GridLength(25);
            col3.Width = new GridLength(158);
            col4.Width = new GridLength(50);
            col5.Width = new GridLength(6);

            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            grid.ColumnDefinitions.Add(col3);
            grid.ColumnDefinitions.Add(col4);
            grid.ColumnDefinitions.Add(col5);

            TextBlock quantity = new TextBlock
            {
                Text = "1",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock name = new TextBlock
            {
                Text = NAME,
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock price = new TextBlock
            {
                Text = $"{PRICE}",
                Foreground = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumn(quantity, 1);
            Grid.SetColumn(name, 2);
            Grid.SetColumn(price, 3);

            grid.Children.Add(quantity);
            grid.Children.Add(name);
            grid.Children.Add(price);

            return grid;
        }


        /// <summary>
        /// Adds Control of structured MenuItem data to Menu xaml.
        /// </summary>
        /// <returns>
        /// Grid layout of MenuItem data.
        /// </returns>
        public Grid CreateDisplayControl()
        {
            if (_Path == null)
            {
                _Path = Path.Combine(Directory.GetCurrentDirectory(), _ASSETS_DIRECTORY);
                _Path = Path.Combine(_Path, _IMAGES_DIRECTORY);
            }

            string file = Path.Combine(_Path, IMAGE);

            Grid grid = new Grid
            {
                Width = 144.5,
                Height = 209.5,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();

            row1.Height = new GridLength(124);
            row2.Height = new GridLength(25);
            row3.Height = new GridLength(15);
            row4.Height = new GridLength(45.5);

            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            grid.RowDefinitions.Add(row3);
            grid.RowDefinitions.Add(row4);

            Image image = LoadImage(file);

            TextBlock name = new TextBlock
            {
                Text = NAME,
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(_White_Smoke),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBlock price = new TextBlock
            {
                Text = $"PRICE: {PRICE}",
                FontSize = 10,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(_White_Smoke),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            Button minus = new Button
            {
                Name = "Minus",
                Margin = new Thickness(0, 5, 0, 0),
                Style = _MenuItemButton,
                Content = "➖",
                Command = CustomerUserInterface.CustomCommands.Minus,
                CommandParameter = this
            };

            Button plus = new Button
            {
                Name = "Plus",
                Margin = new Thickness(0, 5, 0, 0),
                Style = _MenuItemButton,
                Content = "➕",
                Command = CustomerUserInterface.CustomCommands.Plus,
                CommandParameter = this
            };

            Grid.SetColumnSpan(image, 2);
            Grid.SetColumnSpan(name, 2);
            Grid.SetColumnSpan(price, 2);

            Grid.SetColumn(image, 0);
            Grid.SetColumn(name, 0);
            Grid.SetColumn(price, 0);
            Grid.SetColumn(minus, 0);
            Grid.SetColumn(plus, 1);

            Grid.SetRow(image, 0);
            Grid.SetRow(name, 1);
            Grid.SetRow(price, 2);
            Grid.SetRow(minus, 3);
            Grid.SetRow(plus, 3);

            grid.Children.Add(image);
            grid.Children.Add(name);
            grid.Children.Add(price);
            grid.Children.Add(minus);
            grid.Children.Add(plus);

            return grid;
        }


        /// <summary>
        /// Loads image from specified file path. 
        /// </summary>
        /// <param name="file">Image file path.</param>
        /// <returns>
        /// Image from specified file path.
        /// </returns>
        private Image LoadImage(string file)
        {
            Image image = new Image();
            image.Width = 144;
            image.Height = 124;
            ImageSource source = new BitmapImage(new Uri(file));
            image.Source = source;
            return image;
        }
    }
}
