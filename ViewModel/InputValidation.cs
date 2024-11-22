using GoldDigger.Model;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace GoldDigger.ViewModel
{
    internal class InputValidation
    {
        // validate email 
        public static bool IsValidEmail(string emailaddress)
        {
            if (string.IsNullOrEmpty(emailaddress))
            {
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return false;
            }
        }
        // validate string input
        public static bool IsValidStringWithoutNumbers(string name)
        {
            bool isOnlyLetters = Regex.IsMatch(name, "^[a-zA-Z]+$");
            return isOnlyLetters;
        }

        // validate numbers
        public static bool IsNumber(string number)
        {
            bool isOnlyNumeric = Regex.IsMatch(number, "^[0-9]+$");
            return isOnlyNumeric;
        }

        // validate whole row 
        public static void CheckRowInput(CustomerData customer, DataGrid dg, string property)
        {
            // user message if invalid input is detected after row has been commited
            MessageBox.Show($"Please enter a valid {property}!");

            // define a cell info object to refer to location of invalid input
            DataGridCellInfo cell;

            // switch statement that assigns cell info object to data grid row Index of invalid input and clears the corresponding customer property
            switch (property)
            {
                case "Surname":
                    cell = dg.SelectedCells[1];
                    customer.Surname = string.Empty;
                    break;
                case "Lastname":
                    cell = dg.SelectedCells[2];
                    customer.Lastname = string.Empty;
                    break;
                case "City":
                    cell = dg.SelectedCells[3];
                    customer.City = string.Empty;
                    break;
                case "Street":
                    cell = dg.SelectedCells[4];
                    customer.Street = string.Empty;
                    break;
                case "Email":
                    cell = dg.SelectedCells[7];
                    customer.Email = string.Empty;
                    break;
            }
            // define a Framework Element to refer to the content of invalid input   
            FrameworkElement content = dg.Columns[cell.Column.DisplayIndex].GetCellContent(cell.Item);

            // call Framework Element as Text Block for clearing invalid input from data grid
            var textBlock = content as TextBlock;
            if (textBlock != null)
            {
                // Clear the input cell
                textBlock.Text = string.Empty;

                // Force the DataGrid to refresh
                dg.Items.Refresh();
            }
        }
    }
}
