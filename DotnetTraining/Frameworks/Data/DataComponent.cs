using FrameworkExamples.Entities;
using FrameworkExamples.Utils;

//What is the purpose of creating interfaces?
//What is an interface?
//How to create an interface in C#?
namespace FrameworkExamples.Data
{
	interface ICustomerRepo
	{
		void AddNewCustomer(Customer cst);
		void DeleteCustomer(int cstId);
		void UpdateCustomer(Customer cst);
		List<Customer> GetAllCustomers();
	}

    class CsvCustomerRepo : ICustomerRepo
    {
        private readonly string? fileName;
        public CsvCustomerRepo()
        {
            AppSettings.Initialize();
            fileName = AppSettings.Configuration["FileOptions:CsvFilePath"];
        }

        public void AddNewCustomer(Customer cst)
        {
            //Using the File Class, we will append the file with the contents of the customer. 
            if (fileName == null) 
            {
                throw new Exception("FilePath is not set, refer configuration");
            }
            File.AppendAllText(fileName, cst.ToString());   
        }

        public void DeleteCustomer(int cstId)
        {
            //nested functions are new in C# 8.0
            bool finder(Customer cst)
            {
                if(cst.CustomerID == cstId)
                {
                    return true;
                }
                return false;
            }

            //Get all the data from the file
            var records = GetAllCustomers();
            //find the required record
            var foundRec = records.Find(finder);
            //Handle if not found
            if (foundRec == null)
            {
                throw new Exception("No record found to delete");
            }
            //remove the found record
            records.Remove(foundRec);
            //save it back to the file as new set of records
            saveAll(records);
        }

        public List<Customer> GetAllCustomers()
        {
            //create a Temp list
            List<Customer> customers = new List<Customer>();
            //Check if the file is set from the config file or not..
            if (fileName == null)
            {
                throw new Exception("Filepath not set to read the data. Could not read the Config file");
            }
            //Get all the lines from the file
            var lines = File.ReadAllLines(fileName);
            //Iterate thru each line
            foreach (var line in lines)
            {
                //check if the line is empty or null
                if (string.IsNullOrEmpty(line))
                {
                    return customers;
                }
                //Split the line by comma
                var words = line.Split(',');//split the line based on comma...
                //Create customer object for each line
                Customer cst = new Customer();
                //Fill the object with the data 
                cst.BillDate = DateTime.Parse(words[0]);
                cst.CustomerID = int.Parse(words[1]);
                cst.CustomerName = words[2];
                cst.CustomerAddress = words[3];
                cst.BillAmount = int.Parse(words[4]);
                //Add the customer object to the Temp list
                customers.Add(cst);
            }
            //Finally return the Temp list.
            return customers;
        }

        public void UpdateCustomer(Customer cst)
        {
            //Gets all the values
            var customers = GetAllCustomers();
            //find the matching rec in the file.
            var found = customers.Find(c => c.CustomerID == cst.CustomerID);
            //set the new values to the rec
            found.CustomerAddress = cst.CustomerAddress;
            found.BillAmount = cst.BillAmount;
            found.BillDate = cst.BillDate;
            found.CustomerName = cst.CustomerName;
            //update the file..
            saveAll(customers);
        }
        /// <summary>
        /// Helper function used to update the data back to the file..
        /// </summary>
        /// <param name="customers">List of Customers to be updated to the file</param>
        private void saveAll(List<Customer> customers)
        {
            File.WriteAllText(fileName, "");//Will erase the data, not the file.
            foreach (var customer in customers)
            {
                var line = customer.ToString();
                File.AppendAllText(fileName, line);
            }
        }
    }
}