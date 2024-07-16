using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreApp.Models
{
    [Table("BookTable")]
    internal class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } =string.Empty;
        public int Price { get; set; }
    }

    //This class represents the interaction that U do with the database. This class is derived from a EF Library class called DbContext. 
    class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } //This property represents the data of the BookTable U create. 

        private const string DB_SOURCE = ".\\SQLEXPRESS";
        private const string DB_NAME = "FnfTraining";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = $"Data Source={DB_SOURCE};Initial Catalog={DB_NAME};Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    //Open Package manager Console and run the following commands:
    //add-migration mig1
    //update-database




}
