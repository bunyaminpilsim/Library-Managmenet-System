using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        List<Book> _books = new List<Book>();
        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);

            return book;
        }

        public void UpdateBook(Book book)
        {
            var exBook = GetBookById(book.Id);
            if (exBook != null)
            {
                exBook.Title = book.Title;
                exBook.Author = book.Author;
                exBook.PageCount = book.PageCount;
                exBook.File = book.File;
                exBook.CoverImgPath = book.CoverImgPath;
                exBook.CategoryId = book.CategoryId;
                exBook.Categories = book.Categories;
            }
        }
    }
}
