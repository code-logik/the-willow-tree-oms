/**
 * Mark Sarasua
 * www.code-logik.com
 * MainWindow.xaml.cs
 * 30 MARCH 2024
 * 
 */

using OMS;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomerUserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <value>
        /// Property <c>_KMSAPI</c> stores a new instance of OMS.KMSAPI.
        /// </value>
        KMSAPI _KMSAPI = new KMSAPI();

        /// <value>
        /// Property <c>_PSPAPI</c> stores a new instance of OMS.PSPAPI.
        /// </value>
        PSPAPI _PSPAPI = new PSPAPI();

        /// <value>
        /// Property <c>_Entrees</c> stores an array of type Border.
        /// </value>
        private Border[] _Entrees = new Border[8];

        /// <value>
        /// Property <c>_Sides</c> stores an array of type Border.
        /// </value>
        private Border[] _Sides = new Border[8];

        /// <value>
        /// Property <c>_Desserts</c> stores an array of type Border.
        /// </value>
        private Border[] _Desserts = new Border[8];

        /// <value>
        /// Property <c>_Drinks</c> stores an array of type Border.
        /// </value>
        private Border[] _Drinks = new Border[8];

        /// <value>
        /// Property <c>_PERIOD</c> stores the current meal period.
        /// </value>
        private OMS.PERIOD _PERIOD = PERIOD.Breakfast;

        /// <summary>
        /// MainWindow constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeMenuItemBorders();
            AddCustomCommandsExtensions();
            KMSAPI_NewOrder();
            ViewMenu(true);
        }

        /// <summary>
        /// Add Custom Commands Extensions.
        /// </summary>
        private void AddCustomCommandsExtensions() 
        {
            MouseBinding splashscreen_click = new MouseBinding
            (
                new CustomCommandsExtensions((a) => EnterMenu()),
                new MouseGesture(MouseAction.LeftClick)
            );

            if (SplashScreen.InputBindings.Add(splashscreen_click) == 0) 
            {
                SplashScreen.Visibility = Visibility.Visible;
                Initializing.Visibility = Visibility.Collapsed;
            }                                                                                         
        }

        /// <summary>
        /// Invokes KMSAPI NewOrder method.
        /// </summary>
        private void KMSAPI_NewOrder() 
        {
            string[] kmsapi_neworder = _KMSAPI.NewOrder();
            _Server = kmsapi_neworder[0];
            _Table = kmsapi_neworder[1];
        }

        /// <summary>
        /// Determines which menu to display based on meal period.
        /// </summary>
        /// <param name="initialize">Bool value to force LoadMenu() method call.</param>
        private void ViewMenu(bool initialize) 
        {
            int hour = DateTime.Now.Hour;
            OMS.PERIOD period = PERIOD.Breakfast;

            if (hour >= 6 && hour < 11) 
            {
                period = PERIOD.Breakfast;
            }
            else if (hour >= 11 && hour < 17)
            {
                period = PERIOD.Lunch;
            }
            else if (hour >= 17 && hour <= 23) 
            {
                period = PERIOD.Dinner;
            }
            
            if (initialize == true || _PERIOD != period) 
            {
                _PERIOD = period;
                LoadMenu(_PERIOD);
            }
        }

        /// <summary>
        /// Creates a new order.
        /// </summary>
        private void CreateNewOrder() 
        {
            Cash.Content = "ORDER";
            Credit.Content = "CANCEL";
            Cash.IsEnabled = false;
            Credit.IsEnabled = true;
            OrderHead.Children.Add(Header());
            OrderTotal.Children.Add(AddTotals());
        }

        /// <summary>
        /// Loads period based menu from database. 
        /// </summary>
        /// <param name="period">Meal period to load.</param>
        private void LoadMenu(OMS.PERIOD period) 
        {
            OMS.Menu menu = new OMS.Menu();
            List<OMS.MenuItem> menuitems = menu.current_menu(period);

            int a = 0, b = 0, c = 0, d = 0;
            foreach (OMS.MenuItem item in menuitems)
            {
                a %= 8;
                b %= 8;
                c %= 8;
                d %= 8;
                switch (item.CATEGORY)
                {
                    case 1:
                        _Entrees[a++].Child = item.CreateDisplayControl();
                        break;
                    case 2:
                        _Sides[b++].Child = item.CreateDisplayControl();
                        break;
                    case 3:
                        _Desserts[c++].Child = item.CreateDisplayControl();
                        break;
                    case 4:
                        _Drinks[d++].Child = item.CreateDisplayControl();
                        break;
                }
            }
        }

        /// <summary>
        /// Sets Border array elements to respective xaml Borders.
        /// </summary>
        private void InitializeMenuItemBorders() 
        {
            _Entrees[0] = Entree1;
            _Entrees[1] = Entree2;
            _Entrees[2] = Entree3;
            _Entrees[3] = Entree4;
            _Entrees[4] = Entree5;
            _Entrees[5] = Entree6;
            _Entrees[6] = Entree7;
            _Entrees[7] = Entree8;
            _Sides[0] = Side1;
            _Sides[1] = Side2;
            _Sides[2] = Side3;
            _Sides[3] = Side4;
            _Sides[4] = Side5;
            _Sides[5] = Side6;
            _Sides[6] = Side7;
            _Sides[7] = Side8;
            _Desserts[0] = Dessert1;
            _Desserts[1] = Dessert2;
            _Desserts[2] = Dessert3;
            _Desserts[3] = Dessert4;
            _Desserts[4] = Dessert5;
            _Desserts[5] = Dessert6;
            _Desserts[6] = Dessert7;
            _Desserts[7] = Dessert8;
            _Drinks[0] = Drink1;
            _Drinks[1] = Drink2;
            _Drinks[2] = Drink3;
            _Drinks[3] = Drink4;
            _Drinks[4] = Drink5;
            _Drinks[5] = Drink6;
            _Drinks[6] = Drink7;
            _Drinks[7] = Drink8;
        }
    }
}
