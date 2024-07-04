using FrameworkExamples.Data;
using FrameworkExamples.Entities;
using System;

//Using the File IO, we shall store the data of the Customer in the form of CSV. 

namespace FrameworkExamples
{
    internal class Ex08CsvFileIO
    {
        static void Main(string[] args)
        {
           // testForDeleteRecord();
           testForReadingRecords();
           // testForAddingRecord();
            //testForUpdatingRecord();
        }

        private static void testForDeleteRecord()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            repo.DeleteCustomer(111);
        }

        private static void testForUpdatingRecord()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            var cst = new Customer { CustomerID = 111, CustomerAddress = "RR Nagar  Bangalore", CustomerName = "Phani raj" };
            cst.AddToCart(new Product { Id = 11, Name = "Toor Dhal", Price = 200, Quantity = 6 });
            cst.AddToCart(new Product { Id = 12, Name = "Chips", Price = 20, Quantity = 2 });
            repo.UpdateCustomer(cst);
        }

        private static void testForReadingRecords()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            var records = repo.GetAllCustomers();
            foreach (var record in records)
            {
                Console.WriteLine($"Mr/Ms.{record.CustomerName} purchased products with us for an amount of Rs.{record.BillAmount} on {record.BillDate} and the delivery was made to {record.CustomerAddress}");
            }
        }

        private static void testForAddingRecord()
        {
            ICustomerRepo repo = new CsvCustomerRepo();
            var cst = new Customer { CustomerID = 111, CustomerAddress = "Bangalore", CustomerName = "Phaniraj" };
            cst.AddToCart(new Product { Id = 11, Name = "Toor Dhal", Price = 200, Quantity = 5 });
            cst.AddToCart(new Product { Id = 12, Name = "Chips", Price = 20, Quantity = 2 });
            repo.AddNewCustomer(cst);
        }
    }
}
