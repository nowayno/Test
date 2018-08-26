using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BookContext : DbContext
    {
        private const string ConnectString = 
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=book;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public BookContext() : base(ConnectString) {}
        public DbSet<Book> Books { get; set; }
    }
}
