/**
 * Mark Sarasua, Jr.
 * www.code-logik.com
 * 02 APRIL 2024
 * CustomCommands.cs
 * 
 */

using System;
using System.Windows.Input;

namespace CustomerUserInterface
{
    /// <summary>
    /// Class <c>CustomCommands</c> provides commands for binding.
    /// </summary>
    internal static class CustomCommands
    {
        /// <summary>
        /// Event logic for Menu Item + button.
        /// </summary>
        public static readonly RoutedUICommand Plus = new RoutedUICommand();
        
        /// <summary>
        /// Event logic for Menu Item - button.
        /// </summary>
        public static readonly RoutedUICommand Minus = new RoutedUICommand();
    }

    /// <summary>
    /// Class <c>CustomCommandsExtensions</c> extends ICommand class. 
    /// </summary>
    internal class CustomCommandsExtensions : ICommand
    {
        /// <value>
        /// Property <c>CanExecuteChanged</c> is EventHandler.
        /// </value>
        public event EventHandler CanExecuteChanged;

        /// <value>
        /// Property <c>_Execute</c> is Action.
        /// </value>
        Action<object> _Execute;

        /// <summary>
        /// CustomCommandsExtensions constructor.
        /// </summary>
        public CustomCommandsExtensions(Action<object> action) 
        {
            _Execute = action;
        }

        /// <summary>
        /// CanExecute method.
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <returns>Bool.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            _Execute?.Invoke(parameter);
        }
    }
}
