namespace DotnetCoreApp
{
    using DotnetCoreApp.Models;
    using System;

    //To intearct with databases, we use EF Core. EF Core is available for all kinds of databases.
    //We use Nuget packages to download the packages requried to use EF. 
    //MS EF Core, MS EFTools, MS EF SqlServer.
    internal class Program
    {
        static void Main(string[] args)
        {
            addingFeature();
           
        }

        private static void addingFeature()
        {
            //create a book object to represent the data to insert
            var rec = new Book
            {
                Author = "James Clear",
                Title = "Atomic Habits",
                Price = 400
            };

            //Create the DbContext 
            var dbcontext = new BookContext();
            dbcontext.Books.Add(rec);
            dbcontext.SaveChanges();
        }
    }
}
