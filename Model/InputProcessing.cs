using System.Windows;

namespace GoldDigger.Model
{
    internal class InputProcessing
    {
        public static void UpdateCell(int col_index, string newValue, CustomerData customer)
        {
            DBConnect Database = new DBConnect();
            string query = string.Empty;
            switch (col_index)
            {
                case 1:
                    query = $"UPDATE customers SET surname = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 2:
                    query = $"UPDATE customers SET lastname = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 3:
                    query = $"UPDATE customers SET city = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 4:
                    query = $"UPDATE customers SET street = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 5:
                    query = $"UPDATE customers SET no = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 6:
                    query = $"UPDATE customers SET plz = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                case 7:
                    query = $"UPDATE customers SET email = '{newValue}' WHERE id = '{customer.Id}';";
                    Database.Update(query);
                    break;
                
            }
        }

        public static void DeleteCustomer(CustomerData selectedItem)
        {
            string query = $"DELETE FROM customers WHERE id='{selectedItem.Id}';";
            DBConnect Database = new DBConnect();
            Database.Insert(query);
            CustomerData.customerDatas.Remove(selectedItem);
        }
    }
}
