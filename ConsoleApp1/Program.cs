using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private async Task AddBookAsync(string title, string publisher)
        {
            using (var context = new BookContext())
            {
                var book = new Book() { Title = title, Publisher = publisher };
                context.Books.Add(book);
                int records = await context.SaveChangesAsync();
                Console.WriteLine($"{records} record added");
            }
            Console.WriteLine();
        }
        private async Task AddBooksAsync()
        {
            using (var context = new BookContext())
            {
                List<Book> list = new List<Book>()
                {
                    new Book() { Title = "little", Publisher = "the world" },
                    new Book() { Title = "big", Publisher = "ll" },
                    new Book() { Title = "oh", Publisher = "yy" },
                    new Book() { Title = "my", Publisher = "xx" }
                };

                context.Books.AddRange(list);
                int records = await context.SaveChangesAsync();
                Console.WriteLine($"{records} record added");
            }
            Console.WriteLine();
        }
        private void ReadBooks()
        {
            using (var context = new BookContext())
            {
                var books = context.Books;
                var b = from r in books
                        where r.Title == "mm"
                        select r;
                foreach(var book in b)
                {
                    Console.WriteLine($"{book.Title} and {book.Publisher}");
                }
                Console.ReadKey();
            }
        }
        private async Task UpdateAsync(string title, string pulisher)
        {
            using (var context = new BookContext())
            {
                int records = 0;
                var books = context.Books;
                var book = (from b in books
                           where b.Title == "mm"
                           select b).FirstOrDefault();
                if(book != null)
                {
                    book.Title = "xx";
                    records = await context.SaveChangesAsync();
                }
                Console.WriteLine($"{records} record added");
            }
            Console.ReadKey();
        }
        private async Task DeleteAsync()
        {
            using (var context = new BookContext())
            {
                int records = 0;
                var books = context.Books;
                context.Books.RemoveRange(books);
                records = await context.SaveChangesAsync();

                Console.WriteLine($"{records} record added");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            BookService b = new BookService(new BookContext());
            b.AddBooksAsync().Wait();

            //Program p = new Program();
            //p.AddBookAsync("mm", "nn").Wait();
            //p.AddBooksAsync().Wait();
            //p.UpdateAsync("xx", "ss").Wait();
            //p.ReadBooks();
            //p.DeleteAsync().Wait();

        }
    }
}
