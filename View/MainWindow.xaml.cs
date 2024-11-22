using GoldDigger.Model;
using System;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GoldDigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBConnect Database = new DBConnect();

            //Set the DataGrid's DataContext to be a filled DataTable
            
            Database.GetCustomerData();
            CustomerGrid.ItemsSource = CustomerData.customerDatas;
            
        }
        // define bool to prevent triggering CellEditEndingEvent when delete Key is pressed
        bool deleteKeyPressed = false;

        // if user edits a single cell, update its value in the database
        private void CustomerGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            // Cancel Event 
            if (deleteKeyPressed == true)
            {
                e.Cancel = true;
                deleteKeyPressed = false;
            }
            // get edited item and turn it into a customer data object
            var customer = e.Row.Item as CustomerData;

            // get column index of editing element 
            int col_index = e.Column.DisplayIndex;

            // convert editing element into any datatype
            var editingElement = e.EditingElement as TextBox;

            // check if customer has values and valid id, if not stop updating
            if (customer == null || customer.Id == 0)
            {
                return;
            }
            // if user attempts to update Id cancel event and reset cell value
          

            // get column header of editing element
            var header = e.Column.Header;

            // validate string value
            if (header.ToString() == "Surname" || header.ToString() == "Lastname" || header.ToString() == "City" || header.ToString() == "Street")
            {
                if (!ViewModel.InputValidation.IsValidStringWithoutNumbers(editingElement.Text))
                {
                    MessageBox.Show("Input must only contain letters!");

                    editingElement.Clear();
                    return;
                }
            }

            // validate integer value
            if (header.ToString() == "No")
            {
                if (!ViewModel.InputValidation.IsNumber(editingElement.Text)) 
                {
                    MessageBox.Show("Input must be a number!");
                    editingElement.Clear();
                    return;
                }
            }

            // validate Email value
            if (header.ToString() == "Email")
            {
                if (!ViewModel.InputValidation.IsValidEmail(editingElement.Text))
                {
                    
                    editingElement.Clear();
                    return;
                }
            }

            // turn editing element into a string
            string newValue = (e.EditingElement as TextBox)?.Text;

            // open database connection
            DBConnect Database = new DBConnect();
           
            // check if a record with the id of the edited row exists in the database, if yes update the record
            if (Database.Exists(customer.Id))
            {              
                Model.InputProcessing.UpdateCell(col_index, newValue, customer);
            }
        }

        // if user adds a new row of data, save row data as customer object in database
        private void CustomerGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Delay execution until after the edit is committed
            Dispatcher.BeginInvoke(new Action(() =>
            {
                DataGrid dg = sender as DataGrid;
                
                // Retrieve the customer from the edited row
                CustomerData customer = e.Row.Item as CustomerData;

                bool isNewRow = customer != null && customer.Id == 0;

                // Allow event to proceed if it's a new row; otherwise, cancel
                if (!isNewRow)
                {
                    e.Cancel = true; // Cancel the event for existing rows
                    return;
                }

                Thread.Sleep(200);
                if (customer == null)
                    return;

               // validate each input field based on customer property
               foreach (PropertyInfo prop in customer.GetType().GetProperties())
                {
                    var type = prop.PropertyType; //var type = Nullable.GetUnderlyingType(prop.PropertyType);

                    if (type == typeof(string))
                    {
                        if (prop.Name.ToString() == "Email")
                        {
                            if (!ViewModel.InputValidation.IsValidEmail(customer.Email))
                            {
                                ViewModel.InputValidation.CheckRowInput(customer, dg, prop.Name.ToString());                             
                            }
                        }
                        if (prop.Name.ToString() == "Surname")

                        {
                            if(!ViewModel.InputValidation.IsValidStringWithoutNumbers(customer.Surname))
                            {
                                ViewModel.InputValidation.CheckRowInput(customer, dg, prop.Name.ToString());
                            }                            
                        }

                        if (prop.Name.ToString() == "Lastname")
                        {
                            if (!ViewModel.InputValidation.IsValidStringWithoutNumbers(customer.Lastname))
                            {
                                ViewModel.InputValidation.CheckRowInput(customer, dg, prop.Name.ToString());
                            }                            
                        }

                        if (prop.Name.ToString() == "City")
                        {
                            if (!ViewModel.InputValidation.IsValidStringWithoutNumbers(customer.City))
                            {
                                ViewModel.InputValidation.CheckRowInput(customer, dg, prop.Name.ToString());
                            }                           
                        }

                        if (prop.Name.ToString() == "Street")
                        {
                            if (!ViewModel.InputValidation.IsValidStringWithoutNumbers(customer.Street))
                            {
                                ViewModel.InputValidation.CheckRowInput(customer, dg, prop.Name.ToString());
                            }
                        }
                    }                
                }
           
                DBConnect Database = new DBConnect();

                // Check if the row already exists in the database by using the ID
                if (!Database.Exists(customer.Id)) 
                {
                    // Insert the new row into the database
                    string query = $"INSERT INTO customers (surname, lastname, city, street, no, plz, email) VALUES ('{customer.Surname}', '{customer.Lastname}', '{customer.City}', '{customer.Street}', '{customer.No}', '{customer.PLZ}', '{customer.Email}')";
                    Database.Insert(query);

                    int newId = Database.GetLastInsertedId();
                    customer.Id = newId;
                    dg.Items.Refresh();
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }


        // if user deletes a whole row, delete corresponding customer in database
        private void CustomerGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true; // Prevent default behavior to avoid clearing only cell content
                deleteKeyPressed = true;
                // Commit and cancel any active edits to avoid partial edits or placeholder characters
                CustomerGrid.CommitEdit(DataGridEditingUnit.Row, true);
                CustomerGrid.CancelEdit();

                // Get the selected row as a CustomerData object
                var selectedRow = CustomerGrid.SelectedItem as CustomerData;

                // Check if the selected row is valid; if yes, delete the row
                if (selectedRow != null)
                {
                    Model.InputProcessing.DeleteCustomer(selectedRow); // Call delete logic on the model
                    CustomerGrid.Items.Refresh(); // Refresh to reflect changes if necessary
                }
            }
            else { deleteKeyPressed = false; }
        }
    }
}

