/**
 * Mark Sarasua
 * www.code-logik.com
 * EventLogic.cs
 * 02 APRIL 2024
 * 
 */

using OMS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomerUserInterface
{
    /// <summary>
    /// Partial Class <c>MainWindow</c> file EventLogic.cs provides the logic associated with button events.  
    /// </summary>
    partial class MainWindow
    {
        /// <value>
        /// Property <c>_Item</c> stores a new instance of OMS.MenuItem.
        /// </value>
        private OMS.MenuItem _Item = new OMS.MenuItem();

        /// <value>
        /// Property <c>_PaymentMethod</c> stores the method of payment being used.
        /// </value>
        private string _PaymentMethod = string.Empty;

        /// <summary>
        /// Close splash screen and enter menu.
        /// </summary>
        private void EnterMenu()
        {
            CreateNewOrder();
            SplashScreen.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Closes the current order with delay to simulate payment service provider API transactions.
        /// </summary>
        async Task CloseOrder(bool delay)
        {
            if(delay)
            {
                await Task.Delay(3000);
            }
            _Order.Clear();
            _Item = new OMS.MenuItem();
            _PaymentMethod = string.Empty;
            _Tip = _SubTotal = _Sales_Tax = _Total = _Balance_Due = 0M;
            TipSlider.Value = 0.10;
            OrderList.Children.Clear();
            _KMSAPI.Ordered = false;
            OrderMessageTopBorder.Visibility = Visibility.Collapsed;
            OrderMessage.Content = "";
            OrderMessageBottomBorder.Visibility = Visibility.Collapsed;
            Cash.Content = "ORDER";
            Credit.Content = "CANCEL";
            SplashScreen.Visibility = Visibility.Visible;
            PaymentProcessingModal.Visibility = Visibility.Collapsed;
            PaymentModal.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Prepare order for KMSAPI.PlaceOrder call.
        /// </summary>
        /// <returns>
        /// Order of type List<string>
        /// </returns>
        private List<string> UpdateOrder() 
        {
            List<string> order = new List<string>();
            TextBlock textblock;
            bool add = false;
            Grid grid;

            for (int i = 0; i < OrderList.Children.Count; i++)
            {
                grid = (OrderList.Children[i] as Grid);

                for (int j = 0; j < grid.Children.Count; j++)
                {
                    textblock = (grid.Children[j] as TextBlock);

                    if (j == 0)
                    {
                        if (textblock.Text != "1F") 
                        {
                            add = true;
                            textblock.Text += "F";
                        }
                    }
                    else if (j == 1) 
                    {
                        if(add == true)
                        {
                            order.Add(textblock.Text);
                            add = false;
                        }
                    }
                }
            }

            return order;
        }

        /// <summary>
        /// Invoke PSPAPI
        /// </summary>
        private void PayBill_Click(bool process) 
        {
            PaymentModal.Visibility = Visibility.Visible;

            if (process == false)
            {
                if (Credit.IsEnabled == false)
                {
                    Credit.IsEnabled = true;
                }

                Cash.Content = "CASH";
                Credit.Content = "CREDIT";
            }
            else if (process == true)
            {
                List<object[]> order = new List<object[]>();

                for (int i = 0; i < OrderList.Children.Count; i++)
                {
                    object[] lineitem = new object[3];
                    Grid grid = (OrderList.Children[i] as Grid);

                    for (int j = 0; j < 3; j++)
                    {
                        lineitem[j] = (grid.Children[j] as TextBlock).Text;
                    }

                    order.Add(lineitem);
                }

                order.Add(new object[] { _SubTotal });
                order.Add(new object[] { _Sales_Tax });
                order.Add(new object[] { _Total });
                order.Add(new object[] { _Tip });
                order.Add(new object[] { _Balance_Due });
                order.Add(new object[] { _PaymentMethod });

                _PSPAPI.ProcessOrder(order);
            }
        }

        /// <summary>
        /// Send order to KMSAPI.
        /// </summary>
        private void PlaceOrder_Click() 
        {
            List<string> order = UpdateOrder();
            if(order.Count != 0)
            {
                _KMSAPI.PlaceOrder(order);
            }
            Cash.Content = "PAY BILL";
            Credit.Content = "";
        }

        /// <summary>
        /// Cancels current order.
        /// </summary>
        private void CancelOrder_Click() 
        {
            if (_KMSAPI.Ordered == false)
            {
                // go to splash screen
                _ = CloseOrder(false);
            }
            else if (_KMSAPI.Ordered == true) 
            {
                RemoveItems();
            }
        }

        /// <summary>
        /// Disables payment buttons.
        /// </summary>
        private void DisablePaymentButtons()
        {
            if (_Order.Count == 0) 
            {
                Cash.IsEnabled = false;
            }
            else 
            {
                int count = 0;
                
                for (int i = 0; i < OrderList.Children.Count; i++)
                {
                    count += (((OrderList.Children[i] as Grid).Children[0] as TextBlock).Text == "1") ? 1 : 0;
                }

                if (count == 0) 
                {
                    Credit.IsEnabled = false;
                    Cash.Content = "PAY BILL";
                    Credit.Content = "";
                }
            }
        }

        /// <summary>
        /// Exit program logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) 
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Credit card payment button event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Credit_Click(object sender, RoutedEventArgs e)
        {
            Button _sender = (sender as Button);

            if ((string)_sender.Content == "CREDIT" && _Order.Count != 0)
            {
                Cash.IsEnabled = false;
                Cash.Content = "";
                _PaymentMethod = "CREDIT";
                _Tip = Math.Round(((decimal)TipSlider.Value * _Balance_Due), 2);
                TipModalValue.Text = _Tip.ToString("C", CultureInfo.CurrentCulture);
                OrderMessageTopBorder.Visibility = Visibility.Visible;
                OrderMessage.Content = "☙ Thank You for Your Business! ❧";
                OrderMessageBottomBorder.Visibility = Visibility.Visible;
                PaymentModal.Visibility = Visibility.Collapsed;
                TipModal.Visibility = Visibility.Visible;
            }
            else if ((string)_sender.Content == "PAY NOW" && _Order.Count != 0)
            {
                PaymentProcessingModal.Visibility = Visibility.Visible;
                PaymentProcessingModalText.Text = "⏳  Processing Payment...";
                PayBill_Click(true);
                _ = CloseOrder(true);
            }
            else if ((string)_sender.Content == "CANCEL")
            {
                CancelOrder_Click();
            }
        }

        /// <summary>
        /// Cash payment button event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            Button _sender = (sender as Button);

            if ((string)_sender.Content == "CASH" && _Order.Count != 0)
            {
                Credit.IsEnabled = false;
                Credit.Content = "";
                _PaymentMethod = "CASH";
                _Tip = Math.Round(((decimal)TipSlider.Value * _Balance_Due), 2);
                TipModalValue.Text = _Tip.ToString("C", CultureInfo.CurrentCulture);
                OrderMessageTopBorder.Visibility = Visibility.Visible;
                OrderMessage.Content = "☙ Thank You for Your Business! ❧";
                OrderMessageBottomBorder.Visibility = Visibility.Visible;
                PaymentModal.Visibility = Visibility.Collapsed;
                TipModal.Visibility = Visibility.Visible;
            }
            else if ((string)_sender.Content == "PAY NOW" && _Order.Count != 0)
            {
                PaymentProcessingModal.Visibility = Visibility.Visible;
                PaymentProcessingModalText.Text = "⏳  Notifying Server...";
                PayBill_Click(true);
                _ = CloseOrder(true);
            }
            else if ((string)_sender.Content == "ORDER") 
            {
                _KMSAPI.Ordered = true;
                Credit.IsEnabled = false;
                PlaceOrder_Click();
            }
            else if((string)_sender.Content == "PAY BILL") 
            {
                PayBill_Click(false);
            }
        }

        /// <summary>
        /// Add tip button event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void AddTipButton_Click(object sender, RoutedEventArgs e)
        {
            OrderTotal.Children.Add(AddTotals());

            if (_PaymentMethod == "CREDIT")
            {
                Credit.Content = "PAY NOW";
            }
            else if (_PaymentMethod == "CASH")
            {
                Cash.Content = "PAY NOW";
            }

            PaymentModal.Visibility = Visibility.Visible;
            TipModal.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// No tip button event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void NoTipButton_Click(object sender, RoutedEventArgs e)
        {
            if (_PaymentMethod == "CREDIT")
            {
                Credit.Content = "PAY NOW";
            }
            else if (_PaymentMethod == "CASH")
            {
                Cash.Content = "PAY NOW";
            }

            _Tip = Math.Round(0M, 2);
            TipSlider.Value = 0;
            TipModalValue.Text = _Tip.ToString("C", CultureInfo.CurrentCulture);
            PaymentModal.Visibility = Visibility.Visible;
            TipModal.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Tip 10% button logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Tip10Button_Click(object sender, RoutedEventArgs e)
        {
            TipSlider.Value = 0.10;
        }

        /// <summary>
        /// Tip 15% button logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Tip15Button_Click(object sender, RoutedEventArgs e)
        {
            TipSlider.Value = 0.15;
        }

        /// <summary>
        /// Tip 20% button logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Tip20Button_Click(object sender, RoutedEventArgs e)
        {
            TipSlider.Value = 0.20;
        }

        /// <summary>
        /// Tip 25% button logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void Tip25Button_Click(object sender, RoutedEventArgs e)
        {
            TipSlider.Value = 0.25;
        }

        /// <summary>
        /// Tip slider event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void TipSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _Tip = Math.Round((decimal)TipSlider.Value * _Balance_Due, 2);
            TipModalValue.Text = _Tip.ToString("C", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Remove all non-fulfilled order items.
        /// </summary>
        private void RemoveItems() 
        {
            _Order.Reverse();
            int index = -1;

            for (int i = (OrderList.Children.Count - 1); i > -1; i--)
            {
                bool fulfilled = (((OrderList.Children[i] as Grid).Children[0] as TextBlock).Text != "1F");
                string name = ((OrderList.Children[i] as Grid).Children[1] as TextBlock).Text;

                if (fulfilled == true)
                {
                    OrderList.Children.RemoveAt(i);

                    foreach (OMS.MenuItem item in _Order)
                    {
                        index++;

                        if (name == item.NAME)
                        {
                            _Order.RemoveAt(index);
                            break;
                        }
                    }
                }
            }

            _Order.Reverse();
            OrderTotal.Children.Add(AddTotals());
            DisablePaymentButtons();
        }

        /// <summary>
        /// Plus command Executed event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void ExecutedPlus(object sender, ExecutedRoutedEventArgs e)
        {
            if (Cash.IsEnabled == false)
            {
                Cash.IsEnabled = true;
            }

            if (Credit.IsEnabled == false && (string)Cash.Content == "PAY BILL") 
            {
                Cash.Content = "ORDER";
                Credit.Content = "CANCEL";
                Credit.IsEnabled = true;
            }
            
            _Item = (e.Parameter as OMS.MenuItem).DeepCopy();
            _Order.Add(_Item);
            OrderList.Children.Add(_Item.AddItem());
            OrderTotal.Children.Add(AddTotals());
        }

        /// <summary>
        /// Minus command Executed event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void ExecutedMinus(object sender, ExecutedRoutedEventArgs e)
        {
            string dish = string.Empty;
            bool fulfilled = false;
            _Order.Reverse();
            int index = -1;

            for (int i = (OrderList.Children.Count - 1); i > -1; i--)
            {
                dish = ((OrderList.Children[i] as Grid).Children[1] as TextBlock).Text;

                if (dish == (e.Parameter as OMS.MenuItem).NAME)
                {
                    fulfilled = (((OrderList.Children[i] as Grid).Children[0] as TextBlock).Text == "1F");
                    
                    if (fulfilled == false)
                    {
                        OrderList.Children.RemoveAt(i);
                        
                        foreach (OMS.MenuItem item in _Order)
                        {
                            index++;

                            if ((e.Parameter as OMS.MenuItem).NAME == item.NAME)
                            {
                                _Order.RemoveAt(index);
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            _Order.Reverse();
            OrderTotal.Children.Add(AddTotals());
            DisablePaymentButtons();
        }

        /// <summary>
        /// Plus command CanExecute event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void CanExecutePlus(object sender, CanExecuteRoutedEventArgs e)
        {
            Control control = e.Source as Control;

            if (control != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        /// <summary>
        /// Minus command CanExecute event logic.
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Parameters.</param>
        private void CanExecuteMinus(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Source is Control)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
