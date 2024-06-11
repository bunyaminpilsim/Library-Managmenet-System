using LibraryManagementSystem.Models;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateBook(Book book)
        {
            var exBook = _context.Books.FirstOrDefault(x => x.Id == book.Id);
            if (exBook != null)
            {
                exBook.Title = book.Title;
                exBook.Author = book.Author;
                exBook.PageCount = book.PageCount;
                exBook.File = book.File;
                exBook.CoverImgPath = book.CoverImgPath;
                exBook.CategoryId = book.CategoryId;

                _context.SaveChanges();
            }
        }
    }
}
