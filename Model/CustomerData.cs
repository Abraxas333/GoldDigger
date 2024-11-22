using System.Collections.ObjectModel;

namespace GoldDigger.Model
{
    internal class CustomerData
    {
        // getter and setter
        public string Surname { get; set; }
        public string Lastname  { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        
        public int No { get; set; }
        public int PLZ { get; set; }
        public string Email { get; set; }

        public int Id { get; set; }


        // Collection of CustomerData objects 
        public static ObservableCollection<CustomerData> customerDatas = new ObservableCollection<CustomerData>();

        // constructor 
        public CustomerData(string surname, string lastname, string city, string street, int no, int pLZ, string email, int id)
        {
            Surname = surname;
            Lastname = lastname;
            City = city;
            Street = street;   
            No = no;
            PLZ = pLZ;
            Email = email;
            Id = id;    
            customerDatas.Add(this);
        }

        // empty constructor necessary for data grid to offer an empty input row
        public CustomerData() { }
    }
}
