using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BookService
    {
        private BookContext _bookContext;
        public BookService(BookContext context)
        {
            _bookContext = context;
        }
        public async Task AddBooksAsync()
        {
            List<Book> list = new List<Book>()
            {
                new Book() { Title = "c++", Publisher = "yy"},
                new Book() { Title = "c#", Publisher = "zz"},
                new Book() { Title = "c", Publisher = "yy"},
                new Book() { Title = "java", Publisher = "zh"}
            };
            _bookContext.Books.AddRange(list);
            int records = await _bookContext.SaveChangesAsync();
            Console.WriteLine($"{records} record added");
        }
        public async Task GetBooks()
        {
            var books = _bookContext.Books;
            foreach(var book in books)
            {
                Console.WriteLine($"title is {book.Title}, publisher is {book.Publisher}");
            }
        }
    }
}
